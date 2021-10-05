using Features.Clientes;
using MediatR;
using Mock.Tests.Fixture;
using Moq;
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
    }
}