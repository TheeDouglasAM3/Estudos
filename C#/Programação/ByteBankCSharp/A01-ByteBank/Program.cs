using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A01_ByteBank
{
    class Program
    {
        static void Main(string[] args)
        {
            CarregarContas();
            Console.ReadLine();
        }

        private static void CarregarContas()
        {

            using (LeitorDeArquivos leitor = new LeitorDeArquivos("teste.txt"))
            {
                leitor.LerProximaLinha();
            }

            //----------------------------------------------------------------//
            /**LeitorDeArquivos leitor = null;
            try
            {
                leitor = new LeitorDeArquivos("contas.txt");
                leitor.LerProximaLinha();
                leitor.LerProximaLinha();
                leitor.LerProximaLinha();
            }
            catch(IOException e)
            {
                Console.WriteLine(e.Message);
                Console.WriteLine(e.StackTrace);
            }
            finally
            {
                if(leitor != null)
                    leitor.Fechar();
            }**/
            
        }

        private static void TestaInnerException()
        {
            ContaCorrente conta = new ContaCorrente(10, "11");
            ContaCorrente conta2 = new ContaCorrente(11, "12");
            try
            {
                conta.Sacar(1000);
                conta.Tranferir(10000, conta2);
            }
            catch (OperaçãoFinanceiraException e)
            {
                Console.WriteLine(e.Message);
                Console.WriteLine(e.StackTrace);

                Console.WriteLine("\nInformações da INNER EXCEPTION (exceção interna):");

                //Console.WriteLine(e.InnerException.Message);
                //Console.WriteLine(e.StackTrace);
            }
        }

        //Teste com a cadeia de chamada:
        //Metodo -> TestaDivisao -> Dividir
        private static void Metodo()
        {
            TestaDivisao(2);
        }

        private static void TestaDivisao(int divisor)
        {
            try
            {
                int resultado = Dividir(10, divisor);
            }
            catch (NullReferenceException e)
            {
                Console.WriteLine(e.Message);
                Console.WriteLine(e.StackTrace);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Console.WriteLine(e.StackTrace);
            }
            
            //Console.WriteLine("Resultado da divisão de 10 por " + divisor + " é " + resultado);
        }

        private static int Dividir(int numero, int divisor)
        {
            //ContaCorrente conta = null;
            ContaCorrente conta = new ContaCorrente(123, "12345678");
            Console.WriteLine(conta.Saldo);

            try
            {
                return numero / divisor;
            }
            catch (DivideByZeroException)
            {
                Console.WriteLine("Exceção com numero = " + numero + " e divisor = " + divisor);
                throw;
            }
        }
    }
}
