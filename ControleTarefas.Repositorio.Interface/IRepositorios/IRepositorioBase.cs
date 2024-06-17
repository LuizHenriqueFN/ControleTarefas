using ControleTarefas.Entidade.Entidades;

namespace ControleTarefas.Repositorio.Interface.IRepositorios
{
    public interface IRepositorioBase<TEntidade> where TEntidade: class, IEntidade
    {
        Task<TEntidade> ObterPorId(object id);
        Task<List<TEntidade>> Todos();
        Task<TEntidade> Inserir(TEntidade entidade);
        Task Inserir(IEnumerable<TEntidade> entidades);
        Task<TEntidade> Atualizar(TEntidade entidade);
        Task Deletar(TEntidade entidade);
        Task Deletar(IEnumerable<TEntidade> entidades);
        Task DeletarPorId(object id);
    }
}
