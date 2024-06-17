using ControleTarefas.Entidade.Entidades;
using ControleTarefas.Entidade.Model;
using ControleTarefas.Negocio.Interface.INegocios;
using ControleTarefas.Negocio.Negocios;
using ControleTarefas.Repositorio.Interface.IRepositorios;
using ControleTarefas.Repositorio.Repositorios;
using ControleTarefas.Utilitarios.Excepetions;
using ControleTarefas.Utilitarios.Messages;
using NUnit.Framework;

namespace ControleTarefas.TestesUnitarios.BancoEmMemoria
{
    public class TarefaNegocioTeste : TesteUnitarioBase
    {
        private ITarefaNegocio _negocio;
        private ITarefaRepositorio _repositorio;

        [SetUp]
        public void SetUp()
        {
            _repositorio = new TarefaRepositorio(_contexto);

            RegistrarObjeto(typeof(ITarefaRepositorio), _repositorio);

            Registrar<ITarefaNegocio, TarefaNegocio>();

            _negocio = ObterServico<ITarefaNegocio>();
        }

        [Test]
        public void InserirTarefa_Sucesso()
        {
            var tarefa = new CadastroTarefaModel { Titulo = "Titulo Tarefa" };

            async Task action() => await _negocio.InserirTarefa(tarefa);

            Assert.DoesNotThrowAsync(action);
        }

        [TestCase("")]
        [TestCase(null)]
        public void InserirTarefa_TituloInvalido(string titulo)
        {
            //Arrange
            var tarefa = new CadastroTarefaModel { Titulo = titulo };

            //Act
            async Task action() => await _negocio.InserirTarefa(tarefa);

            //Assert
            var excepetion = Assert.ThrowsAsync<BusinessException>(action);
            Assert.IsTrue(excepetion.Message == string.Format(BusinessMessages.CampoObrigatorio, "Título"));
        }

        [Test]
        public void AlterarTarefa_Sucesso()
        {
            //Arrange
            var tarefa = new Tarefa { Titulo = "tarefa" };
            var novoNomeTarefa = "novoNome";
            _contexto.Add(tarefa);
            _contexto.SaveChanges();

            //Act
            async Task action() => await _negocio.AlterarTarefa(tarefa.Titulo, novoNomeTarefa);

            //Assert
            Assert.DoesNotThrowAsync(action);
        }

        [TestCase(null)]
        [TestCase("")]
        public void AlterarTarefa_TituloInvalido(string novoNomeTarefa)
        {
            //Arrange
            var titulo = "tarefaExistente";

            //Act
            async Task action() => await _negocio.AlterarTarefa(titulo, novoNomeTarefa);

            //Assert
            var excepetion = Assert.ThrowsAsync<BusinessException>(action);
            Assert.IsTrue(excepetion.Message == string.Format(BusinessMessages.CampoObrigatorio, "Título"));
        }

        [Test]
        public void DeletarTarefa_Sucesso()
        {
            //Arrange
            var tarefa = new Tarefa { Titulo = "tarefa" };
            var nomeTarefa = "tarefa";
            _contexto.Add(tarefa);
            _contexto.SaveChanges();

            //Act
            async Task action() => await _negocio.DeletarTarefa(nomeTarefa);

            //Assert
            Assert.DoesNotThrowAsync(action);
        }

        [Test]
        public void DeletarTarefa_Inexistente()
        {
            //Arrange
            var nomeTarefa = "tarefa";

            //Act
            async Task action() => await _negocio.DeletarTarefa(nomeTarefa);

            //Assert
            var excepetion = Assert.ThrowsAsync<BusinessException>(action);

            Assert.IsTrue(excepetion.Message == string.Format(BusinessMessages.RegistroNaoEncontrado, nomeTarefa));
        }

        [TestCase("")]
        [TestCase(null)]
        public void DeletarTarefa_TituloInvalido(string nomeTarefa)
        {
            //Act
            async Task action() => await _negocio.DeletarTarefa(nomeTarefa);

            //Assert
            var excepetion = Assert.ThrowsAsync<BusinessException>(action);
            Assert.IsTrue(excepetion.Message == string.Format(BusinessMessages.CampoObrigatorio, "Título"));
        }
    }
}
