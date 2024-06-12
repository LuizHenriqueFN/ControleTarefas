using ControleTarefas.Entidade.DTO;
using ControleTarefas.Entidade.Model;

namespace ControleTarefas.Negocio.Interface.INegocios
{
    public interface ITarefaNegocio
    {
        Task<List<TarefaDTO>> AlterarTarefa(string nomeTarefa, string novoNomeTarefa);
        Task<List<TarefaDTO>> DeletarTarefa(string nomeTarefa);
        Task<List<TarefaDTO>> InserirTarefa(CadastroTarefaModel novaTarefa);
        Task<List<TarefaDTO>> ListarTarefas(List<string> tarefas);
    }
}
