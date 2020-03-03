using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ByteBank.SistemaAgencia
{
    public class ListExtendsHerança<T> : List<T>
    {
        public void AddMultiple(params T[] itens)
        {
            foreach (T item in itens)
            {
                Add(item);
            }
        }
    }
}
