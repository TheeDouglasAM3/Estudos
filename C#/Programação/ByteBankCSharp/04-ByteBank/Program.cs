using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04_ByteBank
{
    class Program
    {
        static void Main(string[] args)
        {
            ContaCorrente conta = new ContaCorrente();
            Console.WriteLine(conta.saldo);
            bool resultadoSaque = conta.Sacar(50);
            Console.WriteLine(resultadoSaque);
            Console.WriteLine(conta.saldo);

            conta.Depositar(1000);
            Console.WriteLine(conta.saldo);

            ContaCorrente conta2 = new ContaCorrente();
            conta2.saldo = 2000;

            Console.WriteLine("Conta 1 = " + conta.saldo);
            Console.WriteLine("Conta 2 = " + conta2.saldo);

            conta.Tranferir(500, conta2);

            Console.WriteLine("Após tranferência de 500 reais da conta 1 pra conta 2");
            Console.WriteLine("Conta 1 = " + conta.saldo);
            Console.WriteLine("Conta 2 = " + conta2.saldo);

            Console.ReadLine();
        }
    }
}
