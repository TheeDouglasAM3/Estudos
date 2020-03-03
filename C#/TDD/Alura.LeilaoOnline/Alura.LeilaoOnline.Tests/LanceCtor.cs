using System;
using System.Collections.Generic;
using System.Text;
using Alura.LeilaoOnline.Core;
using Xunit;

namespace Alura.LeilaoOnline.Tests
{
    public class LanceCtor
    {
        [Fact]
        public void LancaArgumentExceptionDadoValorNegativo()
        {
            //Arranje
            var valorNegativo = -100;

            //Assert
            var exObtida = Assert.Throws<ArgumentException>(
                //Act
                () => new Lance(null, valorNegativo)
            );

            var msgEsperada = "Valor do lance não pode ser negativo.";
            Assert.Equal(exObtida.Message, msgEsperada);
        }
    }
}
