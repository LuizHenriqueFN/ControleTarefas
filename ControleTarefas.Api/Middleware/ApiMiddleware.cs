﻿
using ControleTarefas.Repositorio.Interface;
using ControleTarefas.Utilitarios.Attributes;
using ControleTarefas.Utilitarios.Excepetions;
using ControleTarefas.Utilitarios.Messages;
using ControleTarefas.WebApi.Responses;
using log4net;
using Microsoft.AspNetCore.Http.Features;
using Newtonsoft.Json;
using System.Diagnostics;
using System.Net;

namespace ControleTarefas.WebApi.Middleware
{
    public class ApiMiddleware : IMiddleware
    {
        private static readonly ILog _log = LogManager.GetLogger(typeof(ApiMiddleware));
        private readonly IGerenciadorTransacao _gerenciadorTransacao;

        public ApiMiddleware(IGerenciadorTransacao gerenciadorTransacao)
        {

            _gerenciadorTransacao = gerenciadorTransacao;
        }
        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            Stopwatch stopwatch = new();
            stopwatch.Start();

            var transacaoObrigatoria = context.Features.Get<IEndpointFeature>()?
                .Endpoint?.Metadata.GetMetadata<TransacaoObrigatoriaAttribute>();

            try
            {
                if (transacaoObrigatoria != null)
                {
                    await _gerenciadorTransacao.BeginTransactionAsync(transacaoObrigatoria.IsolationLevel);

                    await next.Invoke(context);

                    await _gerenciadorTransacao.CommitTransactionsAsync();
                }
                else
                {
                    await next.Invoke(context);
                }
                stopwatch.Stop();
                _log.InfoFormat("Serviço executado com sucesso: {0} {1} [{2} ms]", context.Request.Method, context.Request.Path, stopwatch.ElapsedMilliseconds);
            }
            catch (Exception ex)
            {
                if (transacaoObrigatoria != null)
                    await _gerenciadorTransacao.RollbackTransactionsAsync();
                stopwatch.Stop();
                _log.Error($"Erro no serviço: {context.Request.Path} / Mensagem: {ex.Message} [{stopwatch.ElapsedMilliseconds}]", ex);
                await HandleException(context, ex);
            }
        }

        private static async Task HandleException(HttpContext context, Exception exception)
        {
            var response = context.Response;

            response.ContentType = "application/json";

            await response.WriteAsync(JsonConvert.SerializeObject(new DefaultResourses(HttpStatusCode.InternalServerError, GetMessages(exception))));
        }

        private static List<string> GetMessages(Exception exception)
        {
            var messages = new List<string>();

            switch (exception)
            {
                case BusinessException:
                    messages.Add(exception.Message);
                    break;
                case BusinessListException:
                    messages = ((BusinessListException)exception).Messages;
                    break;
                default:
                    messages.Add(string.Format(InfraMessages.ErroInesperado));
                    break;
            }

            return messages;
        }
    }
}
