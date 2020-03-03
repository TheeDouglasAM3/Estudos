using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01_ByteBank
{
    class Program
    {
        static void Main(string[] args)
        {
            ContaCorrente contaDoug = new ContaCorrente();

            contaDoug.titular = "Douglas";
            contaDoug.numAgencia = 863;
            contaDoug.numConta = "123456";
            contaDoug.saldo = 1000;

            Console.WriteLine("Titular: " + contaDoug.titular);
            Console.WriteLine("Número da Agência: " + contaDoug.numAgencia);
            Console.WriteLine("Número da Conta: " + contaDoug.numConta);
            Console.WriteLine("Saldo: " + contaDoug.saldo);

            Console.ReadLine();

        }
    }
}
