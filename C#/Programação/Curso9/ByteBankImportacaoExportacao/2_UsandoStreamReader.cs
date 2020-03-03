using ByteBankImportacaoExportacao.Modelos;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ByteBankImportacaoExportacao
{
    partial class Program
    {
        static void UsandoStreamReader()
        {
            var enderecoDoArquivo = "contas.txt";
            var listaContaCorrente = new List<ContaCorrente>();

            using (var fluxoDeArquivo = new FileStream(enderecoDoArquivo, FileMode.Open))
            using (var leitor = new StreamReader(fluxoDeArquivo))
            {
                while (!leitor.EndOfStream)
                {
                    var linha = leitor.ReadLine();
                    //Console.WriteLine(linha);
                    var conta = ConverterStringParaContaCorrente(linha);
                    listaContaCorrente.Add(conta);
                }
            }

            foreach (var conta in listaContaCorrente)
            {
                Console.WriteLine($"Conta Agência {conta.Agencia} // Número {conta.Numero}");
                Console.WriteLine($"Titular {conta.Titular.Nome} // Saldo {conta.Saldo}");
                Console.WriteLine("");
                //Console.ReadLine();
            }
        }
        static ContaCorrente ConverterStringParaContaCorrente(string linha)
        {
            string[] campos = linha.Split(',');

            var agencia = int.Parse(campos[0]);
            var numero = int.Parse(campos[1]);
            var saldo = double.Parse(campos[2].Replace('.', ','));
            var nomeTitular = campos[3];

            var titular = new Cliente();
            titular.Nome = nomeTitular;

            var conta = new ContaCorrente(agencia, numero);
            conta.Depositar(saldo);
            conta.Titular = titular;

            return conta;
        }
    }
}
