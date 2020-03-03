using System;

namespace _10_While
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Projeto 10 - WHile");

            double valorInvestido = 1000;
            float acrescimo = 0.0036f; //0.36%
            short qtdMesesTotais = 12;
            short qtdMesesPassados = 0;

            while (qtdMesesPassados < qtdMesesTotais)
            {
                valorInvestido += valorInvestido * acrescimo;
                Console.WriteLine("Mes " + (qtdMesesPassados + 1) + ": " + valorInvestido);
                qtdMesesPassados++;
            }


            Console.WriteLine("Enter para sair");
            Console.ReadLine();
        }
    }
}
