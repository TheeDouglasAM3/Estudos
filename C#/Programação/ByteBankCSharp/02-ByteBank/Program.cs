using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02_ByteBank
{
    class Program
    {
        static void Main(string[] args)
        {
            ContaCorrente conta = new ContaCorrente();

            conta.titular = "Douglas";
            conta.numConta = "123456";

            Console.WriteLine("Titular: " + conta.titular);
            Console.WriteLine("Número da Agência: " + conta.numAgencia);
            Console.WriteLine("Número da Conta: " + conta.numConta);
            Console.WriteLine("Saldo: " + conta.saldo);

            Console.ReadLine();
        }
    }
}
