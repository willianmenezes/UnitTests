using Xunit;

namespace Demo.Tests
{
    public class NullBoolAssertionsTests
    {
        [Fact]
        public void Funcionario_Nome_NaoDeveSerNuloOuVazio()
        {
            // arranje && act
            var funcionario = new Funcionario("", 1000);

            // assert
            Assert.False(string.IsNullOrEmpty(funcionario.Nome));
        }

        [Fact]
        public void Funcionario_Apelido_NaoDeveTerApelido()
        {
            // arranje && act
            var funcionario = new Funcionario("Willian", 1000);

            // assert
            Assert.Null(funcionario.Apelido);

            // assert bool
            Assert.True(string.IsNullOrEmpty(funcionario.Apelido));
            Assert.False(funcionario.Apelido?.Length > 0);
        }
    }
}
