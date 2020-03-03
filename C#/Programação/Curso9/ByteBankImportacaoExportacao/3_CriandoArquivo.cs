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
        static void CriarArquivo()
        {
            var caminhoNovoArquivo = "contasexportadas.csv";

            using(var fluxoDeArquivo = new FileStream(caminhoNovoArquivo, FileMode.Create))
            {
                var contaComoString = "123,12345,1200.00,Douglas Marcelino";
                var encoding = Encoding.UTF8;

                var bytes = encoding.GetBytes(contaComoString);


                fluxoDeArquivo.Write(bytes, 0, bytes.Length);
            }
        }

        static void CriarArquivoComWriter()
        {
            var caminhoNovoArquivo = "contasexportadas.csv";

            using (var fluxoDeArquivo = new FileStream(caminhoNovoArquivo, FileMode.CreateNew))
            using (var escritor = new StreamWriter(fluxoDeArquivo)) //using (var escritor = new StreamWriter(fluxoDeArquivo, Encoding.UTF8))
            {
                escritor.Write("123,12345,4000.00,Douglas");
            }
        }

        static void TestaEscrita()
        {
            var caminhoArquivo = "teste.txt";

            using(var fluxoDoArquivo = new FileStream(caminhoArquivo, FileMode.Create))
            using(var escritor = new StreamWriter(fluxoDoArquivo))
            {
                for (int i = 0; i < 1000; i++)
                {
                    escritor.WriteLine($"Linha de índice {i}");

                    escritor.Flush(); //Despeja o buffer para o Stream

                    Console.WriteLine($"Foi escrito \"Linha de índice {i}\", tecle enter para continuar");
                    Console.ReadLine();
                }
            }
        }
    }
}
