
using ControleTarefas.Entidade.DTO;
using ControleTarefas.Entidade.Entidades;
using ControleTarefas.Negocio.Interface.INegocios;
using ControleTarefas.Repositorio.Interface.IRepositorios;
using ControleTarefas.Utilitarios.Excepetions;

namespace ControleTarefas.Negocio.Negocios
{
    public class TarefaNegocio : ITarefaNegocio
    {
        private readonly ITarefaRepositorio _tarefaRepositorio;
        public TarefaNegocio(ITarefaRepositorio tarefaRepositorio)
        {
            _tarefaRepositorio = tarefaRepositorio;
        }

        public List<TarefaDTO> ObterTarefas(List<string>? tarefas)
        {
            if (tarefas == null)
            {
                return _tarefaRepositorio.ObterTodasTarefas();
            }
            else
            {
                tarefas = tarefas.Select(e => e.ToUpper()).ToList();
                return _tarefaRepositorio.ObterTarefas(tarefas);
            }
        }

        public List<TarefaDTO> AdicionarTarefa(string novaTarefa)
        {
            var tarefa = _tarefaRepositorio.ObterTarefaPorTitulo(novaTarefa);

            if (tarefa != null)
                throw new BusinessException($"A tarefa '{novaTarefa}' já existe na base.");

            tarefa = new Tarefa(novaTarefa);

            _tarefaRepositorio.AdicionarTarefa(tarefa);

            return _tarefaRepositorio.ObterTodasTarefas();
        }

        public List<TarefaDTO> AlterarTarefa(string nomeTarefa, string novoNomeTarefa)
        {
            var tarefa = _tarefaRepositorio.ObterTarefaPorTitulo(nomeTarefa);

            if (tarefa != null)
            {
                tarefa.Titulo = novoNomeTarefa;
            }
            else
            {
                throw new BusinessException($"A tarefa '{nomeTarefa}' não existe na base.");
            }

            return _tarefaRepositorio.ObterTodasTarefas();
        }
        
        public List<TarefaDTO> DeletarTarefa(string nomeTarefa)
        {
            var tarefa = _tarefaRepositorio.ObterTarefaPorTitulo(nomeTarefa);

            if (tarefa != null)
            {
                _tarefaRepositorio.DeletarTarefa(tarefa);
            }
            else
            {
                throw new BusinessException($"A tarefa '{nomeTarefa}' não existe na base.");
            }

            return _tarefaRepositorio.ObterTodasTarefas();
        }
    }
}
