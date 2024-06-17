using ControleTarefas.Entidade.DTO;
using ControleTarefas.Entidade.Entidades;
using ControleTarefas.Entidade.Model;
using ControleTarefas.Negocio.Interface.Negocios;
using ControleTarefas.Repositorio.Interface.IRepositorios;
using ControleTarefas.Utilitarios.Excepetions;
using ControleTarefas.Utilitarios.Messages;

namespace ControleTarefas.Negocio.Negocios
{
    public class AtribuirTarefaNegocio : IAtribuirTarefaNegocio
    {
        private readonly IUsuarioRepositorio _usuarioRepositorio;
        private readonly ITarefaRepositorio _tarefaRepositorio;
        public AtribuirTarefaNegocio(IUsuarioRepositorio usuarioRepositorio,
                                     ITarefaRepositorio tarefaRepositorio)
        {
            _usuarioRepositorio = usuarioRepositorio;
            _tarefaRepositorio = tarefaRepositorio;
        }

        private static void ValidarAtribuicaoTarefa(AtribuirTarefaModel tarefasUsuario, Usuario usuario, List<Tarefa> tarefas)
        {
            var exceptions = new List<string>();

            if (usuario == null)
            {
                exceptions.Add(string.Format(BusinessMessages.CampoNaoEncontrado, $"id do usuário {tarefasUsuario.IdUsuario}"));
            }

            foreach (var idTarefa in tarefasUsuario.IdsTarefa)
            {
                if (tarefas.All(t => t.Id != idTarefa))
                    exceptions.Add(string.Format(BusinessMessages.CampoNaoEncontrado, $"id da tarefa {idTarefa}"));
            }

            if (exceptions.Any())
            {
                throw new BusinessListException(exceptions);
            }
        }

        public async Task AtribuirTarefa(AtribuirTarefaModel tarefasUsuario)
        {
            var usuario = await _usuarioRepositorio.ObterUsuario(tarefasUsuario.IdUsuario);
            var tarefas = await _tarefaRepositorio.ConsultarTarefas(tarefasUsuario.IdsTarefa);

            ValidarAtribuicaoTarefa(tarefasUsuario, usuario, tarefas);

            if (usuario != null)
            {
                foreach (var idTarefa in tarefasUsuario.IdsTarefa)
                {
                    if (usuario.TarefasUsuario != null && !usuario.TarefasUsuario.Exists(e => e.IdTarefa == idTarefa))
                    {
                        usuario.TarefasUsuario.Add(new TarefaUsuario
                        {
                            IdUsuario = usuario.Id,
                            IdTarefa = idTarefa
                        });
                    }
                }
            }
        }

        //Com include:
        //  - usuario.TarefasUsuario = novasTarefasUsuario (irá sobrescrever os dados da tabela tb_usuariotarefa)
        //  - usuario.TarefasUsuario.AddRange(novasTarefasUsuario) (irá incrementar com as novas tarefas sem remover as "antigas")
        //Sem include
        //  - usuario.TarefasUsuario = novasTarefasUsuario (irá incrementar com as novas tarefas sem remover as "antigas")

        public async Task<List<TarefaDTO>> ObterTarefasDoUsuario(int idUsuario)
        {
            await _tarefaRepositorio.ConsultarTarefasPorIdUsuario(idUsuario);
            throw new NotImplementedException();
        }

        public Task ObterUsuariosDaTarefa(int idTarefa)
        {
            throw new NotImplementedException();
        }

        public Task RemoverTarefaUsuario(int idTarefa)
        {
            throw new NotImplementedException();
        }
    }
}
