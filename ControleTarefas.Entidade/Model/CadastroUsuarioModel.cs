using ControleTarefas.Entidade.Enum;

namespace ControleTarefas.Entidade.Model
{
    public class CadastroUsuarioModel
    {
        public string Nome { get; set; } = string.Empty;

        public string Email { get; set; } = string.Empty;

        public Perfil Perfil { get; set; }
    }
}
