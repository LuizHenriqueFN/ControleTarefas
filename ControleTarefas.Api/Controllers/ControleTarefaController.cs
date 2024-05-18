using Microsoft.AspNetCore.Mvc;

namespace ControleTarefas.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ControleTarefaController : ControllerBase
    {
        private static List<string> Tarefas { get; set; } = new() { "Instala��o", "Configura��o", "Criar Projeto", "Exerc�cio Pr�tico" };

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
                _logger.LogInformation("A tarefa '{NovaTarefa}' j� existe na base.", novaTarefa);
                throw new BusinessException($"A tarefa '{novaTarefa}' j� existe na base.");
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
                throw new BusinessException($"A tarefa '{nomeTarefa}' n�o existe na base.");

            return Tarefas;
        }

        [HttpPut("AlterarTarefa")]
        public ActionResult<List<string>> AlterarTarefa(string nomeTarefa, string novoNomeTarefa)
        {
            var indexTarefaExistente = Tarefas.FindIndex(tarefa => tarefa == nomeTarefa);

            if (indexTarefaExistente != -1)
                Tarefas[indexTarefaExistente] = novoNomeTarefa;
            else
                throw new BusinessException($"A tarefa '{nomeTarefa}' n�o existe na base.");

            return Tarefas;
        }
    }
}
