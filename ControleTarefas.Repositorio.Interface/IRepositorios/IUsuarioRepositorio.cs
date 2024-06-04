using ControleTarefas.Entidade.DTO;
using ControleTarefas.Entidade.Entidades;

namespace ControleTarefas.Repositorio.Interface.IRepositorios
{
    public interface IUsuarioRepositorio
    {
        List<UsuarioDTO> ObterUsuarios(List<string> emails);

        List<UsuarioDTO> ObterTodosUsuarios();

        void DeletarUsuario(Usuario usuario);

        void AdicionarUsuario(Usuario usuario);

        Usuario? ObterUsuario(string email);
    }
}
