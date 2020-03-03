using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ByteBank.Modelos
{
    public class Cliente
    {
        public string Nome { get; set; }
        public string CPF { get; set; }
        public string Profissao { get; set; }

        public override bool Equals(object obj)
        {
            //Cliente outroCliente = (Cliente)obj;
            Console.WriteLine("Comparando...");
            Cliente outroCliente = obj as Cliente;

            if (outroCliente == null)
            {
                return false;
            }

            //return Nome == outroCliente.Nome && CPF == outroCliente.CPF && Profissao == outroCliente.Profissao;
            return CPF == outroCliente.CPF;
        }
    }
}
