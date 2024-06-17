using ControleTarefas.Entidade.DTO;
using ControleTarefas.Entidade.Entidades;
using ControleTarefas.Repositorio.Interface.IRepositorios;
using Microsoft.EntityFrameworkCore;

namespace ControleTarefas.Repositorio.Repositorios
{
    public class TarefaUsuarioRepositorio : RepositorioBase<TarefaUsuario>, ITarefaUsuarioRepositorio
    {
        public TarefaUsuarioRepositorio(Contexto contexto) : base(contexto) { }
    }
}
