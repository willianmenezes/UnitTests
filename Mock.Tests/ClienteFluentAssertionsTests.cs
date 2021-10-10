using FluentAssertions;
using Mock.Tests.Fixture;
using Xunit;

namespace Mock.Tests
{
    [Collection(nameof(ClienteCollectionBogusMoq))]
    public class ClienteFluentAssertionsTests
    {
        private readonly ClienteTestsFixtureBogusMoq _fixture;

        public ClienteFluentAssertionsTests(ClienteTestsFixtureBogusMoq fixture)
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
            result.Should().Be(true);
            cliente.ValidationResult.Errors.Should().BeEmpty();
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
            result.Should().Be(false); 
            cliente.ValidationResult.Errors.Should().NotBeEmpty(because: "Deve possuir erros de validacao");
        }
    }
}
