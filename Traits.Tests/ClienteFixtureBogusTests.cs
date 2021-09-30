using Traits.Tests.Fixture;
using Xunit;

namespace Traits.Tests
{
    [Collection(nameof(ClienteCollectionBogus))]
    public class ClienteFixtureBogusTests
    {
        private readonly ClienteTestsFixtureBogus _fixture;

        public ClienteFixtureBogusTests(ClienteTestsFixtureBogus fixture)
        {
            _fixture = fixture;
        }

        [Fact(DisplayName = "Novo cliente valido bogus")]
        [Trait("Categoria", "Testes Cliente com fixture bogus")]
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

        [Fact(DisplayName = "Novo cliente invalido bogus")]
        [Trait("Categoria", "Testes Cliente com fixture bogus")]
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
