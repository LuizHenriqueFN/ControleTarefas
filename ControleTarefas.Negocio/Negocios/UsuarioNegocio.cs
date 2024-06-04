
using ControleTarefas.Entidade.DTO;
using ControleTarefas.Entidade.Entidades;
using ControleTarefas.Entidade.Model;
using ControleTarefas.Negocio.Interface.INegocios;
using ControleTarefas.Repositorio.Interface.IRepositorios;
using ControleTarefas.Utilitarios.Excepetions;

namespace ControleTarefas.Negocio.Negocios
{
    public class UsuarioNegocio : IUsuarioNegocio
    {
        private readonly IUsuarioRepositorio _usuarioRepositorio;
        public UsuarioNegocio(IUsuarioRepositorio usuarioRepositorio)
        {
            _usuarioRepositorio = usuarioRepositorio;
        }

        public List<UsuarioDTO> AdicionarUsuario(CadastroUsuarioModel novoUsuario)
        {
            var usuario = _usuarioRepositorio.ObterUsuario(novoUsuario.Email);

            if (usuario != null)
                throw new BusinessException($"O usuario '{novoUsuario.Nome}' já existe na base.");

            usuario = new Usuario
            {
                Email = novoUsuario.Email,
                Nome = novoUsuario.Nome,
                DataAtualizacao = DateTime.Now,
                Perfil = novoUsuario.Perfil
            };

            _usuarioRepositorio.AdicionarUsuario(usuario);

            return _usuarioRepositorio.ObterTodosUsuarios();
        }
    }
}
