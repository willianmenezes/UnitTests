using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Demo.Tests
{
    public  class StringAssertionsTest
    {
        [Fact]
        public void StringTools_UnirNomes_RetornarNomeCompleto()
        {
            //Arranje
            var stringTools = new StringTools();

            // Act
            var nomeCompleto = stringTools.Unir("Willian", "Menezes");

            // Assert
            Assert.Equal("Willian Menezes", nomeCompleto);
        }

        [Fact]
        public void StringTools_UnirNomes_DeveIgnorarCase()
        {
            //Arranje
            var stringTools = new StringTools();

            // Act
            var nomeCompleto = stringTools.Unir("Willian", "Menezes");

            // Assert
            Assert.Equal("WILLIAN MENEZES", nomeCompleto, ignoreCase: true);
        }

        [Fact]
        public void StringTools_UnirNomes_DeveConterTrecho()
        {
            //Arranje
            var stringTools = new StringTools();

            // Act
            var nomeCompleto = stringTools.Unir("Willian", "Menezes");

            // Assert
            Assert.Contains("Will", nomeCompleto);
        }

        [Fact]
        public void StringTools_UnirNomes_DeveComecarCom()
        {
            //Arranje
            var stringTools = new StringTools();

            // Act
            var nomeCompleto = stringTools.Unir("Willian", "Menezes");

            // Assert
            Assert.StartsWith("Wi", nomeCompleto);
        }

        [Fact]
        public void StringTools_UnirNomes_DeveAcabarCom()
        {
            //Arranje
            var stringTools = new StringTools();

            // Act
            var nomeCompleto = stringTools.Unir("Willian", "Menezes");

            // Assert
            Assert.EndsWith("zes", nomeCompleto);
        }

        [Fact]
        public void StringTools_UnirNomes_ValidarExpressaoRegular()
        {
            //Arranje
            var stringTools = new StringTools();

            // Act
            var nomeCompleto = stringTools.Unir("Willian", "Menezes");

            // Assert
            Assert.Matches("[A-Z]{1}[a-z]+ [A-Z]{1}[a-z]+", nomeCompleto);
        }
    }
}
