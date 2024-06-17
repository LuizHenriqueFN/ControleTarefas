using ControleTarefas.Entidade.Entidades;
using ControleTarefas.Entidade.Enum;
using ControleTarefas.Entidade.Model;
using ControleTarefas.Negocio.Interface.INegocios;
using ControleTarefas.Negocio.Negocios;
using ControleTarefas.Repositorio.Interface.IRepositorios;
using ControleTarefas.Utilitarios.Excepetions;
using ControleTarefas.Utilitarios.Messages;
using Moq;
using NUnit.Framework;

namespace ControleTarefas.TestesUnitarios.Mock
{
    public class UsuarioNegocioTeste : TesteUnitarioBase
    {
        private IUsuarioNegocio _negocio;
        private Mock<IUsuarioRepositorio> _mockRepositorio;

        [SetUp]
        public void SetUp()
        {
            Registrar<IUsuarioNegocio, UsuarioNegocio>();
            _mockRepositorio = RegistrarMock<IUsuarioRepositorio>();

            _negocio = ObterServico<IUsuarioNegocio>();
        }

        [TestCase(Perfil.Aluno)]
        [TestCase(Perfil.Professor)]
        public void InserirUsuario_Sucesso(Perfil perfil)
        {
            var novoUsuario = new CadastroUsuarioModel
            {
                Email = "Email",
                Login = "Login",
                Nome = "Nome",
                Perfil = perfil
            };

            _mockRepositorio.Setup(e => e.ObterUsuario(It.IsAny<string>()))
                            .Returns(() => Task.FromResult<Usuario>(null));

            async Task action() => await _negocio.AdicionarUsuario(novoUsuario);

            Assert.DoesNotThrowAsync(action);
        }

        [TestCase(Perfil.Aluno)]
        [TestCase(Perfil.Professor)]
        public void InserirUsuario_UsuarioExistente(Perfil perfil)
        {
            var usuarioExistente = new Usuario
            {
                Email = "Email",
                Login = "Login",
                Nome = "Nome",
                Perfil = perfil
            };

            var novoUsuario = new CadastroUsuarioModel
            {
                Email = "Email",
                Login = "Login",
                Nome = "Nome",
                Perfil = perfil
            };

            _mockRepositorio.Setup(e => e.ObterUsuario(It.IsAny<string>()))
                            .Returns(() => Task.FromResult(usuarioExistente));

            async Task action() => await _negocio.AdicionarUsuario(novoUsuario);

            var exception = Assert.ThrowsAsync<BusinessException>(action);

            Assert.IsTrue(exception.Message == string.Format(BusinessMessages.RegistroExistente, usuarioExistente.Email));
        }
    }
}
