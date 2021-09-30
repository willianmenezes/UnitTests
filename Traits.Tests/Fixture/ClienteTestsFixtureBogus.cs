using Bogus;
using Bogus.DataSets;
using Features.Clientes;
using System;
using Xunit;

namespace Traits.Tests.Fixture
{
    [CollectionDefinition(nameof(ClienteCollectionBogus))]
    public class ClienteCollectionBogus : ICollectionFixture<ClienteTestsFixtureBogus> { }

    public class ClienteTestsFixtureBogus : IDisposable
    {

        public Cliente GerarClienteValido()
        {
            var genero = new Faker().PickRandom<Name.Gender>();

            return new Faker<Cliente>("pt_BR")
                .CustomInstantiator(f => new Cliente(
                    Guid.NewGuid(),
                    f.Name.FindName(gender: genero),
                    f.Name.LastName(gender: genero),
                    f.Date.Past(80, DateTime.Now.AddYears(-18)),
                    "",
                    true,
                    DateTime.Now))
                .RuleFor(c => c.Email, (f,c) => f.Internet.Email(c.Nome.ToLower(), c.Sobrenome.ToLower()));
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
