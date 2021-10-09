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
    public class ClienteServiceTestsAutoMock
    {
        readonly ClienteTestsFixtureBogusMoq _fixture;

        public ClienteServiceTestsAutoMock(ClienteTestsFixtureBogusMoq fixture)
        {
            _fixture = fixture;
        }

        [Fact(DisplayName = "Adicionar cliente com sucesso")]
        [Trait("Categoria", "Cliente service mock tests")]
        public void ClienteService_Adicionar_DeveExecutarComSucesso()
        {
            // arranje 
            var cliente = _fixture.GerarClienteValido();
            var clienteService = _fixture.ObterClienteService();

            // act
            clienteService.Adicionar(cliente);

            // assert
            _fixture.Mocker.GetMock<IClienteRepository>().Verify(r => r.Adicionar(cliente), times: Times.Once);
            _fixture.Mocker.GetMock<IMediator>().Verify(m => m.Publish(It.IsAny<INotification>(), CancellationToken.None), times: Times.Once);
        }

        [Fact(DisplayName = "Erro cliente invalido")]
        [Trait("Categoria", "Cliente service mock tests")]
        public void ClienteService_Adicionar_DeveFalharDevidoClienteInvalido()
        {
            // arranje 
            var cliente = _fixture.GerarClienteInvalido();
            var clienteService = _fixture.ObterClienteService();

            // act
            clienteService.Adicionar(cliente);

            // assert
            _fixture.Mocker.GetMock<IClienteRepository>().Verify(r => r.Adicionar(cliente), times: Times.Never);
            _fixture.Mocker.GetMock<IMediator>().Verify(m => m.Publish(It.IsAny<INotification>(), CancellationToken.None), times: Times.Never);
        }

        [Fact(DisplayName = "Obter todos os cliente ativos")]
        [Trait("Categoria", "Cliente service mock tests")]
        public void ClienteService_ObterAtivos_DeveRetornarApenasClientesAtivos()
        {
            // Arranje
            var clienteService = _fixture.ObterClienteService();

            _fixture.Mocker.GetMock<IClienteRepository>().Setup(r => r.ObterTodos()).Returns(_fixture.GerarClientesVariados());

            // Act
            var clientesAtivos = clienteService.ObterTodosAtivos();

            // Assert
            Assert.True(clientesAtivos.Any());
            Assert.False(clientesAtivos.Count(c => !c.Ativo) > 0);
            _fixture.Mocker.GetMock<IClienteRepository>().Verify(x => x.ObterTodos(), Times.Once);
        }

    }
}