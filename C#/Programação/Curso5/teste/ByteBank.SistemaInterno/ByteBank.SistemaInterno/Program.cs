using ByteBank.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Humanizer;

namespace ByteBank.SistemaInterno
{
    class Program
    {
        static void Main(string[] args)
        {
            //ContaCorrente conta = new ContaCorrente(123, 123);
            //conta.Depositar(1200);
            //conta.Sacar(10);
            //Console.WriteLine(conta.Saldo);


            DateTime dataFimPagamento = new DateTime(2019, 8, 28);
            DateTime dataCorrente = DateTime.Now;
            TimeSpan intervaloTempo = dataFimPagamento - dataCorrente;

            Console.WriteLine(dataCorrente);
            Console.WriteLine(dataFimPagamento);
            Console.WriteLine(TimeSpanHumanizeExtensions.Humanize(intervaloTempo));


            Console.ReadLine();
        }

    }
}
