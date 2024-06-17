using ControleTarefas.Entidade.Entidades;
using ControleTarefas.Entidade.Model;
using ControleTarefas.Negocio.Interface.Negocios;
using ControleTarefas.Repositorio.Interface.IRepositorios;

namespace ControleTarefas.Negocio.Negocios
{
    public class AtribuirTarefaNegocio : IAtribuirTarefaNegocio
    {
        private readonly IUsuarioRepositorio _usuarioRepositorio;
        public AtribuirTarefaNegocio(IUsuarioRepositorio usuarioRepositorio)
        {
            _usuarioRepositorio = usuarioRepositorio;
        }

        public async Task AtribuirTarefa(AtribuirTarefaModel tarefasUsuario)
        {
            var usuario = await _usuarioRepositorio.ObterUsuario(tarefasUsuario.IdUsuario);
            
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

        public Task ObterTarefasDoUsuario(int idUsuario)
        {
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
