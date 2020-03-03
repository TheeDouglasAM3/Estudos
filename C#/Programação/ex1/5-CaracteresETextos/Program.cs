using System;

namespace _5_CaracteresETextos
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Projeto 5 - Caracteres e Textos");

            char primeiraLetra = 'a';
            Console.WriteLine(primeiraLetra);

            primeiraLetra = (char) 65;
            Console.WriteLine(primeiraLetra);

            primeiraLetra = (char) (primeiraLetra + 1);
            Console.WriteLine(primeiraLetra);

            string nome = "Douglas Alves Marcelino";
            Console.WriteLine(nome);

            //string cursos = ".NET \n Java \n PHP";
            string cursos = @".Net
                Java
                PHP";
            Console.WriteLine(cursos);

            Console.WriteLine("Pressione Enter para sair");
            Console.ReadLine();
        }
    }
}
