using System;

namespace _4_ConversoesEOutrosTiposNumericos
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Projeto 4 - Conversoes e outros tipos numericos");

            double salario = 2500.50;
            //int 32 bits
            int salarioInt = (int) salario;

            Console.WriteLine("(double) salario = " + salario);
            Console.WriteLine("(int) salario = " + salarioInt);

            //long 64bits
            long idade;
            idade = 130000000000;

            //short 16bits
            short quantidadeProdutos = 150;

            float altura = 1.80f;

            Console.WriteLine(idade);
            Console.WriteLine(quantidadeProdutos);
            Console.WriteLine(altura);

            Console.WriteLine("Pressione enter para sair...");
            Console.ReadLine();
        }
    }
}
