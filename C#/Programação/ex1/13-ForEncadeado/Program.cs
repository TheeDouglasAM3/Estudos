using System;

namespace _13_ForEncadeado
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Projeto 13 ForEncadeado");

            for (short i = 0; i < 10; i++)
            {
                for (short j = 0; j < i; j++)
                {

                    if (j % 3 == 0)
                    {
                        Console.Write("^");
                    }
                    else
                    {
                        Console.Write("*");
                    }

                    //if (j >= i)
                    //    break;
                }
                Console.WriteLine("");
            }

            Console.WriteLine("Enter para sair...");
            Console.ReadLine();
        }
    }
}
