
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
    public class UsuarioNegocio : IUsuarioNegocio
    {
        private readonly IUsuarioRepositorio _usuarioRepositorio;
        private static readonly ILog _log = LogManager.GetLogger(typeof(UsuarioNegocio));
        public UsuarioNegocio(IUsuarioRepositorio usuarioRepositorio)
        {
            _usuarioRepositorio = usuarioRepositorio;
        }

        public async Task<List<UsuarioDTO>> AdicionarUsuario(CadastroUsuarioModel novoUsuario)
        {
            var usuario = await _usuarioRepositorio.ObterUsuario(novoUsuario.Email);
            if (usuario != null)
            {
                _log.InfoFormat(BusinessMessages.RegistroExistente, usuario.Email);
                throw new BusinessException(string.Format(BusinessMessages.RegistroExistente, usuario.Email));
            }

            usuario = new Usuario
            {
                Email = novoUsuario.Email,
                Nome = novoUsuario.Nome,
                DataAtualizacao = DateTime.Now,
                Perfil = novoUsuario.Perfil
            };

            await _usuarioRepositorio.Inserir(usuario);

            return await _usuarioRepositorio.ListarTodos();
        }
    }
}
