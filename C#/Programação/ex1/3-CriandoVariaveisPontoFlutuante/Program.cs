using System;

namespace _3_CriandoVariaveisPontoFlutuante
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Executando projeto 3 variáveis ponto flutuante.");

            double salario;
            salario = 2500.50;
            Console.WriteLine(salario);

            double idade;
            idade = 15.0 / 2;
            Console.WriteLine(idade);

            idade = 5 / 3;
            Console.WriteLine("(int) 5 / (int) 3 = " + idade);

            idade = 5.0 / 3;
            Console.WriteLine("(double) 5.0 / (int) 3 = " + idade);

            Console.WriteLine("Pressione Enter para sair...");
            Console.ReadLine();
        }
    }
}
