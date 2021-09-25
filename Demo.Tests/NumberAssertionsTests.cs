using Xunit;

namespace Demo.Tests
{
    public class NumberAssertionsTests
    {
        [Fact]
        public void Calculadora_Somar_DeveSerIgual()
        {
            // arranje
            var calculadora = new Calculadora();

            // act 
            var resultado = calculadora.Somar(1, 2);

            // assert
            Assert.Equal(3, resultado);
        }

        [Fact]
        public void Calculadora_Somar_NaoDeveSerIgual()
        {
            // arranje
            var calculadora = new Calculadora();

            // act 
            var resultado = calculadora.Somar(1.123123123123123412, 2.123123123123);

            // assert
            Assert.NotEqual(3.3, resultado, precision: 1);
        }
    }
}
