using Bogus;
using Bogus.DataSets;
using Features.Clientes;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace Mock.Tests.Fixture
{
    [CollectionDefinition(nameof(ClienteCollectionBogusMoq))]
    public class ClienteCollectionBogusMoq : ICollectionFixture<ClienteTestsFixtureBogusMoq> { }

    public class ClienteTestsFixtureBogusMoq : IDisposable
    {

        public Cliente GerarClienteValido()
        {
            return GerarClientes(1, true).First();
        }

        public IEnumerable<Cliente> GerarClientesVariados()
        {
            var clientes = new List<Cliente>();

            clientes.AddRange(GerarClientes(50, true));
            clientes.AddRange(GerarClientes(50, false));

            return clientes;
        }

        public IEnumerable<Cliente> GerarClientes(int quantidade, bool ativo)
        {
            var genero = new Faker().PickRandom<Name.Gender>();

            var cliente = new Faker<Cliente>("pt_BR")
                .CustomInstantiator(f => new Cliente(
                    Guid.NewGuid(),
                    f.Name.FindName(gender: genero),
                    f.Name.LastName(gender: genero),
                    f.Date.Past(80, DateTime.Now.AddYears(-18)),
                    "",
                    ativo,
                    DateTime.Now))
                .RuleFor(c => c.Email, (f, c) => f.Internet.Email(c.Nome.ToLower(), c.Sobrenome.ToLower()));

            return cliente.Generate(quantidade);
        }

        public Cliente GerarClienteInvalido()
        {
            var genero = new Faker().PickRandom<Name.Gender>();

            return new Faker<Cliente>("pt_BR")
                .CustomInstantiator(f => new Cliente(
                    Guid.NewGuid(),
                    f.Name.FindName(gender: genero),
                    f.Name.LastName(gender: genero),
                    f.Date.Past(80, DateTime.Now.AddYears(-18)),
                    "",
                    false,
                    DateTime.Now));
        }

        public void Dispose()
        {
        }
    }
}
