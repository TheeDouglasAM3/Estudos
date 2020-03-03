using ByteBank.Modelos;
using ByteBank.Modelos.Funcionarios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ByteBank.SistemaAgencia
{
    class Program
    {
        static void Main(string[] args)
        {
            //EXEMPLO 1
            /**string url = "pagina?moedaOrigem=real&moedaDestino=dolar";

            int indexInterrogacao = url.IndexOf('?');
            Console.WriteLine(indexInterrogacao);
            Console.WriteLine(url.Substring(++indexInterrogacao));

            int indexMoedaOrigem = url.IndexOf("moedaOrigem");
            Console.WriteLine(url.Substring(indexMoedaOrigem));**/

            //EXEMPLO 2
            /**ExtratorValorDeArgumentoURL extrator = 
                new ExtratorValorDeArgumentoURL("pagina?moedaOrigem=real&moedaDestino=dolar&valor=1500");

            Console.WriteLine(extrator.GetValor("moedaDestINO"));

            string urlTeste = "https://www.bytebank.com/cambio";
            int indiceByteBank = urlTeste.IndexOf("https://www.bytebank.com");

            Console.WriteLine(urlTeste.StartsWith("https://www.bytebank.com"));
            Console.WriteLine(urlTeste.EndsWith("cambio"));
            Console.WriteLine(urlTeste.Contains("bytebank"));**/

            //EXEMPLO 3
            /**string padrao = "[0-9]{4,5}-?[0-9]{4}";
            string texto = "Meu nome é Douglas, e meu numero é 23445-2345";

            Match resultado = Regex.Match(texto, padrao);
            Console.WriteLine(resultado.Value);**/

            //EXEMPLO 4
            /**char charTest = 'c';
            string stringTest = "teste";
            int intTest = 32;
            double doubleTest = 128.5;

            ContaCorrente conta = new ContaCorrente(123, 123);
            Desenvolvedor dev = new Desenvolvedor("123.456.789-99");

            string contaToString = conta.ToString();

            Console.WriteLine(charTest);
            Console.WriteLine(stringTest);
            Console.WriteLine(intTest);
            Console.WriteLine(doubleTest);
            Console.WriteLine(conta);
            Console.WriteLine(dev);
            Console.WriteLine(contaToString);
            Console.WriteLine(conta.GetType());
            Console.WriteLine(contaToString.GetType());**/

            //EXEMPLO 5
            Cliente carlos_1 = new Cliente();
            carlos_1.Nome = "Carlos";
            carlos_1.CPF = "458.623.120-03";
            carlos_1.Profissao = "Designer";

            Cliente carlos_2 = new Cliente();
            carlos_2.Nome = "Carlos";
            carlos_2.CPF = "458.623.120-03";
            carlos_2.Profissao = "Designer";

            if (carlos_1.Equals(carlos_2))
            {
                Console.WriteLine("São iguais!");
            }
            else
            {
                Console.WriteLine("Não são iguais!");
            }

            Console.ReadLine();
        }
    }
}
