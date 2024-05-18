using Microsoft.AspNetCore.Mvc;

namespace ControleTarefas.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ControleTarefaController : ControllerBase
    {
        private static List<string> TitulosTarefas { get; set; } = new() { "Instalação", "Configuração", "Criar Projeto", "Exercício Prático" };

        private readonly ILogger<ControleTarefaController> _logger;

        public ControleTarefaController(ILogger<ControleTarefaController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public ActionResult<List<string>> Get()
        {
            return TitulosTarefas;
        }

        [HttpPost]
        public ActionResult<List<string>> Post(string novaTarefa)
        {
            TitulosTarefas.Add(novaTarefa);
            return TitulosTarefas;
        }

        [HttpDelete]
        public ActionResult<List<string>> Delete(string novaTarefa)
        {
            TitulosTarefas.Remove(novaTarefa);
            return TitulosTarefas;
        }

        [HttpPut]
        public ActionResult<List<string>> Put(string nomeTarefa, string novoNomeTarefa)
        {
            var indexTarefaExistente = TitulosTarefas.FindIndex(tarefa => tarefa == nomeTarefa);

            TitulosTarefas[indexTarefaExistente] = novoNomeTarefa;

            return TitulosTarefas;
        }
    }
}
