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
        static void UsarStreamDeEntrada()
        {
            using (var fluxoDoArquivo = Console.OpenStandardInput())
            using (var fs = new FileStream("saidaConsole.txt", FileMode.Create))
            using (var escritor = new StreamWriter(fs))
            {
                var buffer = new byte[1024];
                var bytesLidos = 0;
                while (bytesLidos != 2)
                {
                    //bytesLidos = fluxoDoArquivo.Read(buffer, 0, 1024);
                    //fs.Write(buffer, 0, bytesLidos);
                    //fs.Flush();

                    escritor.Write(Console.ReadLine());
                    escritor.Flush();

                    Console.WriteLine(bytesLidos);

                }



            }
        }
    }
}
