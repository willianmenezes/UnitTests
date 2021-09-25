using Features.Clientes;
using System;
using Xunit;

namespace Traits.Tests.Fixture
{
    [CollectionDefinition(nameof(ClienteCollection))]
    public class ClienteCollection : ICollectionFixture<ClienteTestsFixture> { }

    public class ClienteTestsFixture : IDisposable
    {

        public Cliente GerarClienteValido()
        {
            return new Cliente(
                    Guid.NewGuid(),
                    "Willian",
                    "Menezes",
                    DateTime.Now.AddYears(-25),
                    "willian@hotmail.com",
                    true,
                    DateTime.Now);
        }

        public Cliente GerarClienteInvalido()
        {
            return new Cliente(
                    Guid.NewGuid(),
                    "",
                    "Menezes",
                    DateTime.Now.AddYears(-25),
                    "willian@hotmail.com",
                    true,
                    DateTime.Now);
        }

        public void Dispose()
        {
        }
    }
}
