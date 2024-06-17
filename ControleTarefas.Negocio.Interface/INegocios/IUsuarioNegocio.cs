using ControleTarefas.Entidade.DTO;
using ControleTarefas.Entidade.Model;

namespace ControleTarefas.Negocio.Interface.INegocios
{
    public interface IUsuarioNegocio
    {
        Task<List<UsuarioDTO>> AdicionarUsuario(CadastroUsuarioModel novoUsuario);
    }
}
