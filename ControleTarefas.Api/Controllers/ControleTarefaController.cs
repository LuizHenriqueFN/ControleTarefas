using Microsoft.AspNetCore.Mvc;

namespace ControleTarefas.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ControleTarefaController : ControllerBase
    {
        private static List<string> Tarefas { get; set; } = new() { "Instalação", "Configuração", "Criar Projeto", "Exercício Prático" };

        private readonly ILogger<ControleTarefaController> _logger;

        public ControleTarefaController(ILogger<ControleTarefaController> logger)
        {
            _logger = logger;
        }

        [HttpGet("ObterTarefas")]
        public ActionResult<List<string>> ObterTarefas()
        {
            return Tarefas;
        }

        [HttpPost("AdicionarTarefa")]
        public ActionResult<List<string>> AdicionarTarefa(string novaTarefa)
        {
            if (Tarefas.Contains(novaTarefa))
            {
                _logger.LogInformation("A tarefa '{NovaTarefa}' já existe na base.", novaTarefa);
                throw new BusinessException($"A tarefa '{novaTarefa}' já existe na base.");
            }

            _logger.LogInformation("A tarefa '{NovaTarefa}' foi inserida.", novaTarefa);
            Tarefas.Add(novaTarefa);

            return Tarefas;
        }

        [HttpDelete("DeletarTarefa")]
        public ActionResult<List<string>> DeletarTarefa(string nomeTarefa)
        {
            var indexTarefaExistente = Tarefas.FindIndex(tarefa => tarefa == nomeTarefa);

            if (indexTarefaExistente != -1)
            {
                Tarefas.Remove(nomeTarefa);
                _logger.LogInformation("A tarefa '{NomeTarefa}' foi removida.", nomeTarefa);
            }
            else
                throw new BusinessException($"A tarefa '{nomeTarefa}' não existe na base.");

            return Tarefas;
        }

        [HttpPut("AlterarTarefa")]
        public ActionResult<List<string>> AlterarTarefa(string nomeTarefa, string novoNomeTarefa)
        {
            var indexTarefaExistente = Tarefas.FindIndex(tarefa => tarefa == nomeTarefa);

            if (indexTarefaExistente != -1)
                Tarefas[indexTarefaExistente] = novoNomeTarefa;
            else
                throw new BusinessException($"A tarefa '{nomeTarefa}' não existe na base.");

            return Tarefas;
        }
    }
}
