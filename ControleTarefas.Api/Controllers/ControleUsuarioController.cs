using ControleTarefas.Entidade.DTO;
using ControleTarefas.Entidade.Model;
using ControleTarefas.Negocio.Interface.INegocios;
using Microsoft.AspNetCore.Mvc;

namespace ControleTarefas.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuarioNegocio _usuarioNegocio;

        public UsuarioController(IUsuarioNegocio usuarioNegocio)
        {
            _usuarioNegocio = usuarioNegocio;
        }

        [HttpPost("AdicionarUsuario")]
        public async Task<List<UsuarioDTO>> AdicionarUsuario(CadastroUsuarioModel novoUsuario)
        {
            return await _usuarioNegocio.AdicionarUsuario(novoUsuario);
        }

    }
}
