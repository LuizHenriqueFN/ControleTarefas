
using System.ComponentModel.DataAnnotations;

namespace ControleTarefas.Entidade.Entidades
{
    public class Tarefa
    {
        [Required(ErrorMessage = "O título é obrigatório.")]
        [MinLength(1, ErrorMessage = "O título deve ter pelo menos um caractere.")]
        public string Titulo { get; set; } = string.Empty;
        public Tarefa()
        {

        }

        public Tarefa(string titulo)
        {
            Titulo = titulo;
        }
    }
}
