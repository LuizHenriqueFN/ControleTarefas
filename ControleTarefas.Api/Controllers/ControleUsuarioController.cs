using ControleTarefas.Entidade.DTO;
using ControleTarefas.Entidade.Model;
using ControleTarefas.Negocio.Interface.INegocios;
using ControleTarefas.Negocio.Interface.Negocios;
using Microsoft.AspNetCore.Mvc;

namespace ControleTarefas.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuarioNegocio _usuarioNegocio;
        private readonly IAtribuirTarefaNegocio _tarefaUsuarioNegocio;

        public UsuarioController(IUsuarioNegocio usuarioNegocio,
                                 IAtribuirTarefaNegocio tarefaUsuarioNegocio)
        {
            _usuarioNegocio = usuarioNegocio;
            _tarefaUsuarioNegocio = tarefaUsuarioNegocio;
        }

        [HttpPost("AdicionarUsuario")]
        public async Task<List<UsuarioDTO>> AdicionarUsuario(CadastroUsuarioModel novoUsuario)
        {
            return await _usuarioNegocio.AdicionarUsuario(novoUsuario);
        }

        [HttpGet("ConsultarTarefasUsuario")]
        public async Task<List<TarefaDTO>> ConsultarTarefasUsuario(int idUsuario)
        {
            return await _tarefaUsuarioNegocio.ObterTarefasDoUsuario(idUsuario);
        }
    }
}
