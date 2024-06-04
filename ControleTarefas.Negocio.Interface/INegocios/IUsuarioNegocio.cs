using ControleTarefas.Entidade.DTO;
using ControleTarefas.Entidade.Model;

namespace ControleTarefas.Negocio.Interface.INegocios
{
    public interface IUsuarioNegocio
    {
        List<UsuarioDTO> AdicionarUsuario(CadastroUsuarioModel novoUsuario);
    }
}
