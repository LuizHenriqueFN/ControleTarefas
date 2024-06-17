using ControleTarefas.Entidade.DTO;
using ControleTarefas.Entidade.Model;
using ControleTarefas.Negocio.Interface.Negocios;
using ControleTarefas.Utilitarios.Attributes;
using Microsoft.AspNetCore.Mvc;

namespace ControleTarefas.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AtribuirTarefaController : ControllerBase
    {
        private readonly IAtribuirTarefaNegocio _atribuirTarefaNegocio;

        public AtribuirTarefaController(IAtribuirTarefaNegocio atribuirTarefaBusiness)
        {
            _atribuirTarefaNegocio = atribuirTarefaBusiness;
        }

        [HttpPost("AtribuirTarefa")]
        [TransacaoObrigatoria]
        public async Task AtribuirTarefa(AtribuirTarefaModel tarefasUsuario)
        {
            await _atribuirTarefaNegocio.AtribuirTarefa(tarefasUsuario);
        }
    }
}
