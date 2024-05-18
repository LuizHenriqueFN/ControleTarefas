
using ControleTarefas.Entidade.DTO;
using ControleTarefas.Entidade.Entidades;
using ControleTarefas.Repositorio.Interface.IRepositorios;

namespace ControleTarefas.Repositorio.Repositorios
{
    public class TarefaRepositorio : ITarefaRepositorio
    {
        private static List<Tarefa> Tarefas { get; set; } = new() { new("Instalação"), new("Configuração"), new("Criar Projeto"), new("Exercício Prático") };

        public List<TarefaDTO> ObterTarefas(List<string> tarefas)
        {
            return Tarefas.Where(tarefa => tarefas.Contains(tarefa.Titulo.ToUpper()))
                          .OrderBy(tarefa => tarefa.Titulo)
                          .Distinct()
                          .Select(tarefa => new TarefaDTO
                          {
                              Titulo = tarefa.Titulo
                          })
                          .ToList();
        }

        public List<TarefaDTO> ObterTodasTarefas()
        {
            return Tarefas.OrderBy(tarefa => tarefa.Titulo)
                          .Distinct()
                          .Select(tarefa => new TarefaDTO
                          {
                              Titulo = tarefa.Titulo
                          })
                          .ToList();
        }

        public void DeletarTarefa(Tarefa tarefa)
        {
            Tarefas.Remove(tarefa);
        }

        public void AdicionarTarefa(Tarefa tarefa)
        {
            Tarefas.Add(tarefa);
        }

        public Tarefa? ObterTarefaPorTitulo(string tituloTarefa)
        {
            return Tarefas.Find(e => e.Titulo.ToLower() == tituloTarefa.ToLower());
        }
    }
}
