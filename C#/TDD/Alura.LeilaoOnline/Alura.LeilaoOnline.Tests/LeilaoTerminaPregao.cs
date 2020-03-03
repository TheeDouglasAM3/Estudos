using Alura.LeilaoOnline.Core;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Alura.LeilaoOnline.Tests
{
    public class LeilaoTerminaPregao
    {
        [Theory]
        [InlineData(new double[] { 800, 900, 1000, 1200 }, 1200),]
        [InlineData(new double[] { 800, 900, 1000, 990 }, 1000)]
        [InlineData(new double[] { 800 }, 800)]
        public void RetornaMaiorValorDadoLeilaoComPeloMenosUmLance(double[] ofertas, double valorEsperado)
        {
            //Arranje
            var modalidade = new MaiorValor();
            var leilao = new Leilao("Van gogh", modalidade);

            leilao.IniciaPregao();
            var interessados = new List<Interessada>()
            {
                new Interessada("Doug", leilao),
                new Interessada("Maria", leilao),
                new Interessada("Willian", leilao)
            };
            var interessadoOferta = 0;

            foreach (var valor in ofertas)
            {
                leilao.RecebeLance(interessados[interessadoOferta], valor);
                interessadoOferta++;
                if ((interessadoOferta + 1) > interessados.Count)
                    interessadoOferta = 0;
            }

            //Act
            leilao.TerminaPregao();

            //Assert
            var valorObtido = leilao.Ganhador.Valor;
            Assert.Equal(valorEsperado, valorObtido);
        }

        [Fact]
        public void LancaInvalidOperationExceptionDadoPregaoNaoIniciado()
        {
            //Arranje
            var modalidade = new MaiorValor();
            var leilao = new Leilao("Van gogh", modalidade);

            var excecaoObtida = Assert.Throws<InvalidOperationException>(
                //Act
                () => leilao.TerminaPregao()
            );

            var msgEsperada = "Não é possível terminar o pregão sem que ele seja iniciado.";
            Assert.Equal(excecaoObtida.Message, msgEsperada);
        }

        [Fact]
        public void RetornaZeroDadoLeilaoSemLances()
        {
            //Arranje
            IModalidadeAvaliacao modalidade = new MaiorValor();
            var leilao = new Leilao("Van gogh", modalidade);
            leilao.IniciaPregao();

            //Act
            leilao.TerminaPregao();

            //Assert
            var valorEsperado = 0;
            var valorObtido = leilao.Ganhador.Valor;
            Assert.Equal(valorEsperado, valorObtido);
        }

        [Theory]
        [InlineData(1250, 1200, new double[] { 800, 1150, 1400, 1250})]
        public void RetornaValorSuperiorMaiorProximoDadoLeilaoNessaModalidade(
            double valorEsperado, double valorDestino, double[] ofertas)
        {
            //Arranje
            IModalidadeAvaliacao modalidade = new OfertaSuperiorMaisProxima(valorDestino);
            var leilao = new Leilao("Van gogh", modalidade);

            leilao.IniciaPregao();
            var interessados = new List<Interessada>()
            {
                new Interessada("Doug", leilao),
                new Interessada("Maria", leilao),
                new Interessada("Willian", leilao)
            };
            var interessadoOferta = 0;

            foreach (var valor in ofertas)
            {
                leilao.RecebeLance(interessados[interessadoOferta], valor);
                interessadoOferta++;
                if ((interessadoOferta + 1) > interessados.Count)
                    interessadoOferta = 0;
            }

            //Act
            leilao.TerminaPregao();

            //Assert
            var valorObtido = leilao.Ganhador.Valor;
            Assert.Equal(valorEsperado, valorObtido);
        }
    }
}
