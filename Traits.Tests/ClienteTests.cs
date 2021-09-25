using Features.Clientes;
using System;
using Xunit;

namespace Traits.Tests
{
    public class ClienteTests
    {
        [Fact(DisplayName = "Novo cliente valido")]
        [Trait("Categoria", "Testes Cliente")]
        public void Cliente_NovoCliente_DeveEstarValido()
        {
            // arranje
            var cliente = new Cliente(
                    Guid.NewGuid(),
                    "Willian",
                    "Menezes",
                    DateTime.Now.AddYears(-25),
                    "willian@hotmail.com",
                    true,
                    DateTime.Now);

            //act
            var result = cliente.EhValido();

            //assert
            Assert.True(result);
            Assert.Empty(cliente.ValidationResult.Errors);
        }

        [Fact(DisplayName = "Novo cliente invalido")]
        [Trait("Categoria", "Testes Cliente")]
        public void Cliente_NovoCliente_DeveEstarInvalido()
        {
            // arranje
            var cliente = new Cliente(
                    Guid.NewGuid(),
                    "",
                    "Menezes",
                    DateTime.Now.AddYears(-25),
                    "willian@hotmail.com",
                    true,
                    DateTime.Now);

            //act
            var result = cliente.EhValido();

            //assert
            Assert.False(result);
            Assert.NotEmpty(cliente.ValidationResult.Errors);
        }
    }
}
