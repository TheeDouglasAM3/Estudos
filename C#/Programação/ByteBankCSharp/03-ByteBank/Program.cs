using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03_ByteBank
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

            ContaCorrente contaDoug2 = new ContaCorrente();

            contaDoug2.titular = "Douglas";
            contaDoug2.numAgencia = 863;
            contaDoug2.numConta = "123456";
            contaDoug2.saldo = 1000;

            Console.WriteLine("Igualdade de referência: " + (contaDoug.titular == contaDoug2.titular));
            Console.WriteLine("Igualdade de valores: " + (contaDoug == contaDoug2));

            contaDoug = contaDoug2;
            Console.WriteLine("Igualdade de referência após uma receber a outra: " + (contaDoug == contaDoug2));

            contaDoug.saldo = 300;
            Console.WriteLine(contaDoug.saldo);
            Console.WriteLine(contaDoug2.saldo);

            int numExample = 300;
            Console.WriteLine("double 300 == int 300" + (contaDoug.saldo == numExample));

            Console.ReadLine();
        }
    }
}
