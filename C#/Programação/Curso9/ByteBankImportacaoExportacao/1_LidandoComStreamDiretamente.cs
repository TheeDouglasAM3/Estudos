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
        static void LidandoComFileStream()
        {
            var enderecoDoArquivo = "contas.txt";

            using (var fluxoDoArquivo = new FileStream(enderecoDoArquivo, FileMode.Open))
            {
                LerTodoArquivo(fluxoDoArquivo, 1024);
            }
        }

        static void LerTodoArquivo(FileStream file, int tamanhoBufferBytes, int offset = 0)
        {
            int numeroBytesLidos = -1;
            var buffer = new byte[tamanhoBufferBytes];

            while (numeroBytesLidos != 0)
            {
                numeroBytesLidos = file.Read(buffer, offset, tamanhoBufferBytes);
                EscreverBuffer(buffer, numeroBytesLidos);
            }
        }

        static void EscreverBuffer(byte[] buffer, int bytesLidos)
        {
            var utf8 = new UTF8Encoding(); //Encoding.UTF8; Encoding.Default;
            var texto = utf8.GetString(buffer, 0, bytesLidos);
            Console.Write(texto);

            /**foreach (var meuByte in buffer)
            {
                Console.Write(meuByte);
                Console.Write(" ");
            }**/
        }

        static void Exercicio1()
        {
            var fs = new FileStream("teste.txt", FileMode.Open);

            var buffer = new byte[1024];
            var encoding = Encoding.ASCII;

            var bytesLidos = fs.Read(buffer, 0, 1024);
            var conteudoArquivo = encoding.GetString(buffer, 0, bytesLidos);


            Console.Write(conteudoArquivo);
            Console.ReadLine();
        }
    }
}

