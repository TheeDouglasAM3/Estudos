using System;

namespace _12_FORFOR
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Projeto 12 - FOR FOR");

            double valorInvestido = 1000;
            float acrescimo = 1.0036f; //0.36%
            short qtdMesesTotais = 12;
            short qtdAnosTotais = 5;

            for (short i = 0; i < qtdAnosTotais; i++)
            {

                for (short j = 0; j < qtdMesesTotais; j++)
                {
                    short mes = (short) (i * 12 + j + 1);
                    valorInvestido *= acrescimo;
                    Console.WriteLine("Valor mês " + mes + ": " + valorInvestido);
                }

                acrescimo += 0.0010f;

            }

            Console.WriteLine("Enter para sair");
            Console.ReadLine();
        }
    }
}
