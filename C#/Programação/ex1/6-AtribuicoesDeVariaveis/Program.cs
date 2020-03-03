using System;

namespace _6_AtribuicoesDeVariaveis
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Projeto 6 - Atribuições de variavies");

            int idade = 5;
            int idadeDoug = 16 + idade;

            idade = 30;

            Console.WriteLine(idade);
            Console.WriteLine(idadeDoug);

            Console.WriteLine("Enter para sair...");
            Console.ReadLine();
        }
    }
}
