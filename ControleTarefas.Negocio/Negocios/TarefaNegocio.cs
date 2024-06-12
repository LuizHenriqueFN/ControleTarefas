
using ControleTarefas.Entidade.DTO;
using ControleTarefas.Entidade.Entidades;
using ControleTarefas.Entidade.Model;
using ControleTarefas.Negocio.Interface.INegocios;
using ControleTarefas.Repositorio.Interface.IRepositorios;
using ControleTarefas.Utilitarios.Excepetions;
using ControleTarefas.Utilitarios.Messages;
using log4net;

namespace ControleTarefas.Negocio.Negocios
{
    public class TarefaNegocio : ITarefaNegocio
    {
        private readonly ITarefaRepositorio _tarefaRepositorio;
        private static readonly ILog _log = LogManager.GetLogger(typeof(TarefaNegocio));

        public TarefaNegocio(ITarefaRepositorio tarefaRepositorio)
        {
            _tarefaRepositorio = tarefaRepositorio;
        }

        public Task<List<TarefaDTO>> ListarTarefas(List<string> tarefas)
        {
            if (tarefas == null)
            {
                return _tarefaRepositorio.ListarTodas();
            }
            else
            {
                tarefas = tarefas.Select(e => e.ToUpper())
                                 .ToList();

                return _tarefaRepositorio.ListarTarefas(tarefas);
            }
        }

        public async Task<List<TarefaDTO>> InserirTarefa(CadastroTarefaModel novaTarefa)
        {
            var tarefa = await _tarefaRepositorio.ObterTarefa(novaTarefa.Titulo);

            if (tarefa != null)
                throw new BusinessException(string.Format(BusinessMessages.RegistroExistente, "Título"));

            tarefa = new Tarefa(novaTarefa.Titulo);

            await _tarefaRepositorio.Inserir(tarefa);

            _log.InfoFormat("A tarefa '{0}' foi inserida.", novaTarefa);
            return await _tarefaRepositorio.ListarTodas();
        }

        public async Task<List<TarefaDTO>> AlterarTarefa(string nomeTarefa, string novoNomeTarefa)
        {
            var tarefa = await _tarefaRepositorio.ObterTarefa(nomeTarefa);

            if (tarefa != null)
            {
                tarefa.Titulo = novoNomeTarefa;
                await _tarefaRepositorio.Atualizar(tarefa);
                _log.InfoFormat("A tarefa '{0}' foi atualizada para o nome {1}.", nomeTarefa, novoNomeTarefa);
            }
            else
            {
                _log.InfoFormat("A tarefa '{0}' não existe na base.", nomeTarefa);
                throw new BusinessException($"A tarefa '{nomeTarefa}' não existe na base.");
            }

            return await _tarefaRepositorio.ListarTodas();
        }

        public async Task<List<TarefaDTO>> DeletarTarefa(string nomeTarefa)
        {
            var tarefa = await _tarefaRepositorio.ObterTarefa(nomeTarefa);

            if (tarefa != null)
            {
                await _tarefaRepositorio.Deletar(tarefa);
                _log.InfoFormat("A tarefa '{0}' foi removida.", nomeTarefa);
            }
            else
            {
                _log.InfoFormat("A tarefa '{0}' não existe na base.", nomeTarefa);
                throw new BusinessException(string.Format(BusinessMessages.RegistroNaoEncontrado, nomeTarefa));
            }

            return await _tarefaRepositorio.ListarTodas();
        }
    }
}
