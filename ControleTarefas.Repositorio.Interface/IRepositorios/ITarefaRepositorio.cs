using ControleTarefas.Entidade.DTO;
using ControleTarefas.Entidade.Entidades;

namespace ControleTarefas.Repositorio.Interface.IRepositorios
{
    public interface ITarefaRepositorio
    {
        List<TarefaDTO> ObterTarefas(List<string> tarefas);

        List<TarefaDTO> ObterTodasTarefas();

        void DeletarTarefa(Tarefa tarefa);

        void AdicionarTarefa(Tarefa tarefa);

        Tarefa? ObterTarefaPorTitulo(string tituloTarefa);
    }
}
