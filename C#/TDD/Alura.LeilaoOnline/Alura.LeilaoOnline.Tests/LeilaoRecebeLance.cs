using Alura.LeilaoOnline.Core;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Xunit;

namespace Alura.LeilaoOnline.Tests
{
    public class LeilaoRecebeLance
    {
        [Fact]
        public void NaoAceitaProximoLanceDadoMesmoClienteRealizouUltimoLance()
        {
            //Arranje
            var modalidade = new MaiorValor();
            var leilao = new Leilao("Escudo capitão america", modalidade);
            var cliente = new Interessada("Douglas", leilao);

            leilao.IniciaPregao();
            leilao.RecebeLance(cliente, 1300);

            //Act
            leilao.RecebeLance(cliente, 1400);

            //Assert
            var valorEsperado = 1;
            var valorObtido = leilao.Lances.Count();
            Assert.Equal(valorEsperado, valorObtido);
        }

        [Theory]
        [InlineData(new double[] { 800, 900, 1000 }, 3)]
        [InlineData(new double[] { 800 }, 1)]
        public void NãoPermiteNovosLancesDadoLeilaoFinalizado(double[] ofertas, int qtdEsperada)
        {
            //Arranje
            var modalidade = new MaiorValor();
            var leilao = new Leilao("Van gogh", modalidade);

            leilao.IniciaPregao();
            //var individuo = new interessada("douglas", leilao);
            var clientes = new List<Interessada>()
            {
                new Interessada("Douglas", leilao),
                new Interessada("Costelinha", leilao)
            };
            var clienteOferta = 0;

            foreach (var oferta in ofertas)
            {
                leilao.RecebeLance(clientes[clienteOferta], oferta);
                clienteOferta++;
                if ((clienteOferta + 1) > clientes.Count())
                    clienteOferta = 0;
            }
            leilao.TerminaPregao();

            //Act
            leilao.RecebeLance(clientes[0], 1000);

            //Assert
            var valorEsperado = qtdEsperada;
            var valorObtido = leilao.Lances.Count();

            Assert.Equal(valorEsperado, valorObtido);
        }
    }
}
