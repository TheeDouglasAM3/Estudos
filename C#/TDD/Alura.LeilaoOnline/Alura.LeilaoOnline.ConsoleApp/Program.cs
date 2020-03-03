using Alura.LeilaoOnline.Core;
using System;
using System.Collections.Generic;

namespace Alura.LeilaoOnline.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            LeilaoComVariosLances();
            LeilaoComUmLance();
        }

        private static void Verificar(double esperado, double obtido)
        {
            var originalColorConsole = Console.ForegroundColor;
            if (esperado == obtido)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("TESTE OK");
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"TESTE FALHOU\nValor Esperado: {esperado}\nObtido: {obtido}");
            }
            Console.ForegroundColor = originalColorConsole;
        }

        private static void LeilaoComUmLance()
        {
            //Arranje
            var modalidade = new MaiorValor();
            var leilao = new Leilao("Quadro", modalidade);
            var interessados = new List<Interessada>()
            {
                new Interessada("Doug", leilao)
            };

            leilao.RecebeLance(interessados[0], 200);

            //Act
            leilao.TerminaPregao();

            //Assert
            var valorEsperado = 200;
            var valorObtido = leilao.Ganhador.Valor;
            Verificar(valorEsperado, valorObtido);
        }

        private static void LeilaoComVariosLances()
        {
            //Arranje
            var modalidade = new MaiorValor();
            var leilao = new Leilao("Van gogh", modalidade);
            var interessados = new List<Interessada>()
            {
                new Interessada("Doug", leilao),
                new Interessada("Maria", leilao)
            };

            leilao.RecebeLance(interessados[0], 800);
            leilao.RecebeLance(interessados[1], 900);
            leilao.RecebeLance(interessados[0], 1000);
            leilao.RecebeLance(interessados[1], 990);

            //Act
            leilao.TerminaPregao();

            //Assert
            var valorEsperado = 1000;
            var valorObtido = leilao.Ganhador.Valor;
            Verificar(valorEsperado, valorObtido);
        }

    }
}
