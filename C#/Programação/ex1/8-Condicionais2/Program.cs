using System;

namespace _8_Condicionais2
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Projeto 8 - Condicionais 2");

            short idadeDoug = 21;
            short qtdPessoas = 2;
            bool maiorIdade = idadeDoug >= 18;
            bool acompanhado = qtdPessoas >= 2;

            if (maiorIdade && acompanhado)
            {
                Console.WriteLine("Acesso permitido");
            }
            else
            {
                Console.WriteLine("ACESSO NEGADO");
            }

            Console.WriteLine("Pressione Enter para sair");
            Console.ReadLine();
        }
    }
}
