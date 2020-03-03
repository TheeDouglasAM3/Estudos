using System;

namespace _7_Condicionais
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Projeto 7 - Condicionais");

            short idadeDoug = 21;
            short qtdPessoas = 1;

            if (idadeDoug >= 18 || qtdPessoas >= 2)
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
