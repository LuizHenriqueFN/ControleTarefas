
using ControleTarefas.Entidade.DTO;
using ControleTarefas.Entidade.Entidades;
using ControleTarefas.Repositorio.Interface.IRepositorios;
using Microsoft.EntityFrameworkCore;

namespace ControleTarefas.Repositorio.Repositorios
{
    public class TarefaRepositorio : RepositorioBase<Tarefa>, ITarefaRepositorio
    {
        public TarefaRepositorio(Contexto contexto) : base(contexto) { }

        public Task<List<TarefaDTO>> ListarTarefas(List<string> tarefas)
        {
            var query = EntitySet.Where(tarefa => tarefas.Contains(tarefa.Titulo.ToUpper()))
                                 .Select(tarefa => new TarefaDTO
                                 {
                                     Titulo = tarefa.Titulo
                                 })
                                 .OrderBy(tarefa => tarefa.Titulo)
                                 .Distinct();

            return query.ToListAsync();
        }

        public Task<List<TarefaDTO>> ListarTodas()
        {
            var query = EntitySet.Select(tarefa => new TarefaDTO
            {
                Titulo = tarefa.Titulo
            })
                                 .OrderBy(e => e.Titulo)
                                 .Distinct();

            return query.ToListAsync();
        }

        public Task<List<Tarefa>> ConsultarTarefas(List<int> idsTarefa)
        {
            var query = EntitySet.Include(e => e.UsuarioTarefa).ThenInclude(e => e.Usuario).Where(e => idsTarefa.Contains(e.Id));

            return query.ToListAsync();
        }

        public Task<List<TarefaDTO>> ConsultarTarefasPorIdUsuario(int idUsuario)
        {
            var query2 = EntitySet.Where(tarefa => tarefa.UsuarioTarefa.Any(usuarioTarefa => usuarioTarefa.IdUsuario == idUsuario));

            var query = from tarefa in _contexto.Tarefas
                        join tarefaUsuario in _contexto.TarefaUsuario
                            on tarefa.Id equals tarefaUsuario.IdTarefa
                        join usuario in _contexto.Usuario
                            on tarefaUsuario.IdUsuario equals usuario.Id
                        where usuario.Id == idUsuario
                        select new TarefaDTO
                        {
                            Titulo = tarefa.Titulo
                        };

            return query.ToListAsync();
        }

        public Task<Tarefa?> ObterTarefa(string tituloTarefa, bool asNoTracking = false)
        {
            var query = EntitySet.AsQueryable();

            if (asNoTracking)
                query = query.AsNoTracking();

            return query.FirstOrDefaultAsync(e => e.Titulo.ToLower() == tituloTarefa.ToLower());
        }
    }
}
