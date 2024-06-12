using ControleTarefas.Entidade.DTO;
using ControleTarefas.Entidade.Model;
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
        public async Task<List<TarefaDTO>> ObterTarefas()
        {
            return await _tarefaNegocio.ListarTarefas(null);
        }

        [HttpGet("FiltrarTarefas")]
        public async Task<List<TarefaDTO>> FiltrarTarefas(string tarefas)
        {
            return await _tarefaNegocio.ListarTarefas(new List<string>() { tarefas });
        }

        [HttpPost("AdicionarTarefa")]
        public async Task<List<TarefaDTO>> AdicionarTarefa(CadastroTarefaModel novaTarefa)
        {
            return await _tarefaNegocio.InserirTarefa(novaTarefa);
        }

        [HttpDelete("DeletarTarefa")]
        public async Task<List<TarefaDTO>> DeletarTarefa(string nomeTarefa)
        {
            return await _tarefaNegocio.DeletarTarefa(nomeTarefa);
        }

        [HttpPut("AlterarTarefa")]
        public async Task<List<TarefaDTO>> AlterarTarefa(string nomeTarefa, string novoNomeTarefa)
        {
            return await _tarefaNegocio.AlterarTarefa(nomeTarefa, novoNomeTarefa);
        }
    }
}
