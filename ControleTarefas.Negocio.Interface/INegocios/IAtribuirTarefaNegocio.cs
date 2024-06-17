using ControleTarefas.Entidade.DTO;
using ControleTarefas.Entidade.Model;

namespace ControleTarefas.Negocio.Interface.Negocios
{
    public interface IAtribuirTarefaNegocio
    {
        Task AtribuirTarefa(AtribuirTarefaModel tarefasUsuario);
        Task ObterUsuariosDaTarefa(int idTarefa);
        Task ObterTarefasDoUsuario(int idUsuario);
        Task RemoverTarefaUsuario(int idTarefa);
    }
}
