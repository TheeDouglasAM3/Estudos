using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _05_ByteBank
{
    class Program
    {
        static void Main(string[] args)
        {
            /**Cliente cliente = new Cliente();
            cliente.nome = "Douglas";
            cliente.cpf = "12345678";
            cliente.profissao = "programador";**/

            ContaCorrente conta = new ContaCorrente();

            conta.titular = new Cliente();
            conta.titular.nome = "Douglas";
            conta.titular.cpf = "12345678";
            conta.titular.profissao = "programador";

            conta.numAgencia = 123;
            conta.numConta = "3213124";
            conta.saldo = 2000;

            if (conta.titular == null)
                Console.WriteLine("A referencia em conta.titular é null");

            Console.WriteLine("Cliente: " + conta.titular.nome);
            Console.WriteLine("Cpf: " + conta.titular.cpf);
            Console.WriteLine("Profissão: " + conta.titular.profissao);
            Console.WriteLine("Agência: " + conta.numAgencia);
            Console.WriteLine("Conta: " + conta.numConta);
            Console.WriteLine("Saldo: " + conta.saldo);

            Console.ReadLine();
        }
    }
}
