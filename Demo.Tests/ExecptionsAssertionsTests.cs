using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Demo.Tests
{
    public class ExecptionsAssertionsTests
    {
        [Fact]
        public void Calculadora_Dividir_DeveRetornarErroDivisaoPorZero()
        {
            // arranje
            var calculadora = new Calculadora();

            // act & assert
            Assert.Throws<DivideByZeroException>(() => calculadora.Dividir(10, 0));
        }

        [Fact]
        public void Funcionario_Salario_DeveRetornarErroSalarioInferiorPermitido()
        {
            // Arranje & Act & Assert
            var exception = Assert.Throws<Exception>(() => FuncionarioFactory.Criar("Willian", 100));

            Assert.Equal("Salario inferior ao permitido", exception.Message);
        }
    }
}
