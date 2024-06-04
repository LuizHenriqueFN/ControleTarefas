using ControleTarefas.Entidade.DTO;
using ControleTarefas.Entidade.Model;

namespace ControleTarefas.Negocio.Interface.INegocios
{
    public interface ITarefaNegocio
    {
        List<TarefaDTO> ObterTarefas(List<string>? tarefas);
        
        List<TarefaDTO> AdicionarTarefa(CadastroTarefaModel novaTarefa);

        List<TarefaDTO> AlterarTarefa(string nomeTarefa, string novoNomeTarefa);
       
        List<TarefaDTO> DeletarTarefa(string nomeTarefa);
    }
}
