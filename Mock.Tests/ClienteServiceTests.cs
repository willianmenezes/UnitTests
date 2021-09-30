using Features.Clientes;
using MediatR;
using Moq;
using Traits.Tests.Fixture;
using Xunit;

namespace Mock.Tests
{
    [Collection(nameof(ClienteCollectionBogus))]
    public class ClienteServiceTests
    {
        private readonly ClienteTestsFixtureBogus _fixture;
        public ClienteServiceTests(ClienteTestsFixtureBogus fixture)
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
        }
    }
}