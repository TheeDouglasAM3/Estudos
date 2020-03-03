using System;

namespace _11_For
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Projeto 11 - FOR");

            double valorInvestido = 1000;
            float acrescimo = 1.0036f; //0.36%
            short qtdMesesTotais = 12;

            for (short i = 0; i < qtdMesesTotais; i++)
            {
                valorInvestido *= acrescimo;
                Console.WriteLine("Valor mês " + (i + 1) + ": " + valorInvestido);
            }

            Console.WriteLine("Enter para sair");
            Console.ReadLine();
        }
    }
}
