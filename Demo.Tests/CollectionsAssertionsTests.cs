using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Demo.Tests
{
    public class CollectionsAssertionsTests
    {
        [Fact]
        public void Funcionario_Habilidades_NaoDevePosssuirHabilidadesVazias()
        {
            // arranje && act
            var funcionario = FuncionarioFactory.Criar("Willian", 10000);

            // assert 
            Assert.All(funcionario.Habilidades, habilidade => Assert.False(string.IsNullOrWhiteSpace(habilidade)));
        }

        [Fact]
        public void Funcionario_Habilidades_JuniorDevePossuirHabilidadesBasicas()
        {
            // arranje && act
            var funcionario = FuncionarioFactory.Criar("Willian", 1000);

            // assert 
            Assert.Contains("OOP", funcionario.Habilidades);
        }

        [Fact]
        public void Funcionario_Habilidades_JuniorNaoDevePossuirHabilidadesAvancadas()
        {
            // arranje && act
            var funcionario = FuncionarioFactory.Criar("Willian", 1000);

            // assert 
            Assert.DoesNotContain("Testes", funcionario.Habilidades);
        }

        [Fact]
        public void Funcionario_Habilidades_SeniorDevePossuirTodasHabilidades()
        {
            // arranje && act
            var funcionario = FuncionarioFactory.Criar("Willian", 10000);

            var habilidades = new[]
            {
                "Logica de programacao",
                "OOP",
                "Testes",
                "Microsservicos"
            };

            // assert 
            Assert.Equal(habilidades, funcionario.Habilidades);
        }
    }
}
