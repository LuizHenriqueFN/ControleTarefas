using ControleTarefas.Entidade.DTO;
using ControleTarefas.Negocio.Interface.INegocios;
using Microsoft.AspNetCore.Mvc;

namespace ControleTarefas.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ControleTarefaController : ControllerBase
    {
        private readonly ITarefaNegocio _tarefaNegocio;

        public ControleTarefaController(ILogger<ControleTarefaController> logger, ITarefaNegocio tarefaNegocio)
        {
            _tarefaNegocio = tarefaNegocio;
        }

        [HttpGet("ObterTarefas")]
        public ActionResult<List<TarefaDTO>> ObterTarefas()
        {
            return _tarefaNegocio.ObterTarefas(null);
        }

        [HttpGet("FiltrarTarefas")]
        public ActionResult<List<TarefaDTO>> FiltrarTarefas(string tarefas)
        {
            return _tarefaNegocio.ObterTarefas(new List<string>() { tarefas });
        }

        [HttpPost("AdicionarTarefa")]
        public ActionResult<List<TarefaDTO>> AdicionarTarefa(string novaTarefa)
        {
            return _tarefaNegocio.AdicionarTarefa(novaTarefa);
        }

        [HttpDelete("DeletarTarefa")]
        public ActionResult<List<TarefaDTO>> DeletarTarefa(string nomeTarefa)
        {
            return _tarefaNegocio.DeletarTarefa(nomeTarefa);
        }

        [HttpPut("AlterarTarefa")]
        public ActionResult<List<TarefaDTO>> AlterarTarefa(string nomeTarefa, string novoNomeTarefa)
        {
            return _tarefaNegocio.AlterarTarefa(nomeTarefa, novoNomeTarefa);
        }
    }
}
