using Traits.Tests.Fixture;
using Xunit;

namespace Traits.Tests
{
    [Collection(nameof(ClienteCollection))]
    public class ClienteFixtureTests
    {
        private readonly ClienteTestsFixture _fixture;

        public ClienteFixtureTests(ClienteTestsFixture fixture)
        {
            _fixture = fixture;
        }

        [Fact(DisplayName = "Novo cliente valido")]
        [Trait("Categoria", "Testes Cliente com fixture")]
        public void Cliente_NovoCliente_DeveEstarValido()
        {
            // arranje
            var cliente = _fixture.GerarClienteValido();

            //act
            var result = cliente.EhValido();

            //assert
            Assert.True(result);
            Assert.Empty(cliente.ValidationResult.Errors);
        }

        [Fact(DisplayName = "Novo cliente invalido")]
        [Trait("Categoria", "Testes Cliente com fixture")]
        public void Cliente_NovoCliente_DeveEstarInvalido()
        {
            // arranje
            var cliente = _fixture.GerarClienteInvalido();

            //act
            var result = cliente.EhValido();

            //assert
            Assert.False(result);
            Assert.NotEmpty(cliente.ValidationResult.Errors);
        }
    }
}
