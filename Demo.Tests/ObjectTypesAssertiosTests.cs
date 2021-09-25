using Xunit;

namespace Demo.Tests
{
    public class ObjectTypesAssertiosTests
    {
        [Fact]
        public void FuncionarioFactory_Criar_DeveRetornarTipoFuncionario()
        {
            // arranje && act
            var funcionario = FuncionarioFactory.Criar("Willian", 10000);

            // assert 
            Assert.IsType<Funcionario>(funcionario);
        }

        [Fact]
        public void FuncionarioFactory_Criar_DeveRetornarTipoDerivadoPessoa()
        {
            // arranje && act
            var funcionario = FuncionarioFactory.Criar("Willian", 10000);

            // assert 
            Assert.IsAssignableFrom<Pessoa>(funcionario);
        }
    }
}
