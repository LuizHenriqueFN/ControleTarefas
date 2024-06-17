
using ControleTarefas.Entidade.Enum;

namespace ControleTarefas.Entidade.Entidades
{
    public class Usuario: IdEntidade<int>
    {
        public string Nome { get; set; } = string.Empty;

        public string Login { get; set; } = string.Empty;

        public string Email { get; set; } = string.Empty;

        public Perfil Perfil { get; set; }
        
        public DateTime DataAtualizacao { get; set; }

        public List<TarefaUsuario> TarefasUsuario { get; set; }

        public Usuario()
        {

        }

    }
}
