/**using System;
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
            ContaCorrente conta = new ContaCorrente(10, "11");
            ContaCorrente conta2 = new ContaCorrente(11, "12");
            try
            {
                conta.Depositar(10000);
                conta.Sacar(100);
                conta.Tranferir(20000, conta2);
            }
            catch (ArgumentException e)
            {
                Console.WriteLine("Ocorreu uma ArgumentException");
                Console.WriteLine(e.ParamName);
                Console.WriteLine(e.Message);
                Console.WriteLine(e.StackTrace);
            }
            catch (SaldoInsuficienteException e)
            {
                Console.WriteLine("Exceção do tipo SaldoInsuficienteException");
                Console.WriteLine(e.Message);
                Console.WriteLine(e.StackTrace);
            }
            /**catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Console.WriteLine(e.StackTrace);
            }

            

            Metodo();

            Console.ReadLine();
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
}**/
