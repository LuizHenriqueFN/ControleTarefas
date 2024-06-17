namespace ControleTarefas.Entidade.Entidades
{
    public class TarefaUsuario : IEntidade
    {
        public int IdUsuario { get; set; }
        public int IdTarefa { get; set; }
        public bool Concluida { get; set; }
        public Tarefa Tarefa { get; set; }
        public Usuario Usuario { get; set; }

        public TarefaUsuario()
        {

        }
    }
}
