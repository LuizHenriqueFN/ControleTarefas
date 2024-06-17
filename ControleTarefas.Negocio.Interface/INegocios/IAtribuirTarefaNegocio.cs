using ControleTarefas.Entidade.DTO;
using ControleTarefas.Entidade.Model;

namespace ControleTarefas.Negocio.Interface.Negocios
{
    public interface IAtribuirTarefaNegocio
    {
        Task AtribuirTarefa(AtribuirTarefaModel tarefasUsuario);
        Task ObterUsuariosDaTarefa(int idTarefa);
        Task<List<TarefaDTO>> ObterTarefasDoUsuario(int idUsuario);
        Task RemoverTarefaUsuario(int idTarefa);
    }
}
