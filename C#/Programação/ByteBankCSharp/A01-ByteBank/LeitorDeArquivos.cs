using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A01_ByteBank
{
    class LeitorDeArquivos : IDisposable
    {
        public string Arquivo { get; }

        public LeitorDeArquivos(string arquivo)
        {
            Arquivo = arquivo;

            //throw new FileNotFoundException();

            Console.WriteLine("Abrindo o arquivo: " + arquivo);
        }

        public string LerProximaLinha()
        {
            Console.WriteLine("Lendo linha ...");

            //throw new IOException();

            return "Linha do arquivo";
        }

        /**public void Fechar()
        {
            Console.WriteLine("Fechando Arquivo.");
        }**/

        public void Dispose()
        {
            Console.WriteLine("Fechando Arquivo.");
        }
    }
}
