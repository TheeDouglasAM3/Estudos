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
        static void EscritaBinario()
        {
            using(var fs = new FileStream("contaCorrente.txt", FileMode.Create))
            using (var escritor = new BinaryWriter(fs))
            {
                escritor.Write(123);
                escritor.Write(12345);
                escritor.Write(4000.50);
                escritor.Write("Douglas");
            }
        }

        static void LerBinario()
        {
            using(var fs = new FileStream("contaCorrente.txt", FileMode.Open))
            using(var leitor = new BinaryReader(fs))
            {
                var agencia = leitor.ReadInt32();
                var numero = leitor.ReadInt32();
                var saldo = leitor.ReadDouble();
                var titular = leitor.ReadString();

                Console.WriteLine($"Agência {agencia}");
                Console.WriteLine($"Número {numero}");
                Console.WriteLine($"Saldo {saldo}");
                Console.WriteLine($"Titular {titular}");
            }
        }
    }
}
