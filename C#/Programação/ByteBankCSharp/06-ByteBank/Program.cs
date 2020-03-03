using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _06_ByteBank
{
    class Program
    {
        static void Main(string[] args)
        {
            ContaCorrente conta = new ContaCorrente();
            Cliente cliente = new Cliente();

            cliente.Nome = "Douglas";
            cliente.Cpf = "1234567";
            cliente.Profissao = "dev";

            conta.Titular = cliente;

            conta.Saldo = 150;
            
            Console.WriteLine(conta.Saldo);
            Console.WriteLine(conta.Titular.Nome);
            Console.ReadLine();
        }
    }
}
