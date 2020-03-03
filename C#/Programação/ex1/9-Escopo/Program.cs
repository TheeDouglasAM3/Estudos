using System;

namespace _9_Escopo
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Projeto 9 - Escopo");

            short idadeDoug = 21;
            short qtdPessoas = 1;
            bool maiorIdade = idadeDoug >= 18;
            bool acompanhado = qtdPessoas >= 2;
            string msgAdd;

            if (acompanhado == true)
                msgAdd = "Doug está acompanhado";
            else
                msgAdd = "Doug não está acompanhado";

            if (maiorIdade && acompanhado)
            {
                Console.WriteLine("Acesso permitido");
                Console.WriteLine(msgAdd);
            }
            else
            {
                Console.WriteLine("ACESSO NEGADO");
                Console.WriteLine(msgAdd);
            }   

            Console.WriteLine("Pressione enter para sair...");
            Console.ReadLine();
        }
    }
}
