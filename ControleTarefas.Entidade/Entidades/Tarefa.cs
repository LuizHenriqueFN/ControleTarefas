
using System.ComponentModel.DataAnnotations;

namespace ControleTarefas.Entidade.Entidades
{
    public class Tarefa: IdEntidade<int>
    {
        public string Titulo { get; set; } = string.Empty;
        public List<TarefaUsuario> UsuariosTarefa { get; set; }
        public Tarefa()
        {

        }

        public Tarefa(string titulo)
        {
            Titulo = titulo;
        }
    }
}
