using ByteBank.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ByteBank.SistemaAgencia.Comparators
{
    public class ComparadorContaCorrentePorAgenciaENumero : IComparer<ContaCorrente>
    {

        public int Compare(ContaCorrente x, ContaCorrente y)
        {
            // Retornar negativo quando a instância precede o obj
            // Retornar zero quando nossa instância e obj forem equivalentes;
            // Retornar positivo diferente de zero quando a precedência for de obj;
            if (x == y)
                return 0;

            if (x == null)
                return 1;

            if (y == null)
                return -1;

            int compareAgencia = x.Agencia.CompareTo(y.Agencia);

            if(compareAgencia == 0)
                return x.Numero.CompareTo(y.Numero);

            return compareAgencia;
        }
    }
}
