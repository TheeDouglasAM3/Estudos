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
        static void Main(string[] args) 
        {
            // Read the file into <bits>
            var fs = new FileStream("archive", FileMode.Open);
            var len = (int)fs.Length;
            var bits = new byte[len];
            fs.Read(bits, 0, len);
            // Dump 16 bytes per line
            for (int ix = 0; ix < len; ix += 16)
            {
                var cnt = Math.Min(16, len - ix);
                var line = new byte[cnt];
                Array.Copy(bits, ix, line, 0, cnt);
                // Write address + hex + ascii
                //Console.Write("{0:X6}  ", ix);
                Console.Write(BitConverter.ToString(line));
                //Console.Write("  ");
                // Convert non-ascii characters to .
                for (int jx = 0; jx < cnt; ++jx)
                    if (line[jx] < 0x20 || line[jx] > 0x7f) line[jx] = (byte)'.';
                //Console.WriteLine(Encoding.ASCII.GetString(line));
                Console.WriteLine(Encoding.UTF8.GetString(line));
            }
            Console.ReadLine();
            Console.ReadLine();
        }

        static void TestaTipos()
        {
            using (var fs = new FileStream("testaTipos.txt", FileMode.Create))
            using (var escritor = new StreamWriter(fs))
            {
                escritor.WriteLine(true);
                escritor.WriteLine(false);
                escritor.WriteLine(37283);
            }
        }

        
    }
} 
 