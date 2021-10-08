using Features.Clientes;
using MediatR;
using Mock.Tests.Fixture;
using Moq;
using System.Linq;
using System.Threading;
using Xunit;

namespace Mock.Tests
{
    [Collection(nameof(ClienteCollectionBogusMoq))]
    public class ClienteServiceTestsMock
    {
        readonly ClienteTestsFixtureBogusMoq _fixture;

        public ClienteServiceTestsMock(ClienteTestsFixtureBogusMoq fixture)
        {
            _fixture = fixture;
        }

        [Fact(DisplayName = "Adicionar cliente com sucesso")]
        [Trait("Categoria", "Cliente service mock tests")]
        public void ClienteService_Adicionar_DeveExecutarComSucesso()
        {
            // arranje 
            var cliente = _fixture.GerarClienteValido();
            var clienteRepository = new Mock<IClienteRepository>();
            var mediator = new Mock<IMediator>();

            var clienteService = new ClienteService(clienteRepository.Object, mediator.Object);

            // act
            clienteService.Adicionar(cliente);

            // assert
            clienteRepository.Verify(r => r.Adicionar(cliente), times: Times.Once);
            mediator.Verify(m => m.Publish(It.IsAny<INotification>(), CancellationToken.None), times: Times.Once);
        }

        [Fact(DisplayName = "Erro cliente invalido")]
        [Trait("Categoria", "Cliente service mock tests")]
        public void ClienteService_Adicionar_DeveFalharDevidoClienteInvalido()
        {
            // arranje 
            var cliente = _fixture.GerarClienteInvalido();
            var clienteRepository = new Mock<IClienteRepository>();
            var mediator = new Mock<IMediator>();

            var clienteService = new ClienteService(clienteRepository.Object, mediator.Object);

            // act
            clienteService.Adicionar(cliente);

            // assert
            clienteRepository.Verify(r => r.Adicionar(cliente), times: Times.Never);
            mediator.Verify(m => m.Publish(It.IsAny<INotification>(), CancellationToken.None), times: Times.Never);
        }

        [Fact(DisplayName = "Obter todos os cliente ativos")]
        [Trait("Categoria", "Cliente service mock tests")]
        public void ClienteService_ObterAtivos_DeveRetornarApenasClientesAtivos()
        {
            // Arranje
            var clienteRepository = new Mock<IClienteRepository>();
            var mediator = new Mock<IMediator>();

            var clienteService = new ClienteService(clienteRepository.Object, mediator.Object);

            clienteRepository.Setup(r => r.ObterTodos()).Returns(_fixture.GerarClientesVariados());

            // Act
            var clientesAtivos = clienteService.ObterTodosAtivos();

            // Assert
            Assert.True(clientesAtivos.Any());
            Assert.False(clientesAtivos.Count(c => !c.Ativo) > 0);
            clienteRepository.Verify(x => x.ObterTodos(), Times.Once);
        }

    }
}