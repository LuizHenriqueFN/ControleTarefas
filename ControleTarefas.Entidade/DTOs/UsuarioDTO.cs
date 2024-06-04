using ControleTarefas.Entidade.Enum;

namespace ControleTarefas.Entidade.DTO
{
    public class UsuarioDTO
    {
        public string Nome { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public Perfil Perfil { get; set; }
        public DateTime DataAtualizacao { get; set; }
    }
}
