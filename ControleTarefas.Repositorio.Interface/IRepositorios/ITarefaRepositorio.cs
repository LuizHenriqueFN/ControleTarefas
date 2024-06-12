using ControleTarefas.Entidade.DTO;
using ControleTarefas.Entidade.Entidades;

namespace ControleTarefas.Repositorio.Interface.IRepositorios
{
    public interface ITarefaRepositorio: IRepositorioBase<Tarefa>
    {
        Task<List<TarefaDTO>> ListarTarefas(List<string> tarefas);
        Task<List<TarefaDTO>> ListarTodas();
        Task<Tarefa> ObterTarefa(string tituloTarefa, bool asNoTracking = false);
    }
}
