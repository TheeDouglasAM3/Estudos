using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace CasaDoCodigo.Models.ViewModels
{
    [DataContract]
    public class CarrinhoViewModel
    {
        public CarrinhoViewModel(IList<ItemPedido> itens)
        {
            Itens = itens;
        }
        [DataMember]
        public IList<ItemPedido> Itens { get; }

        [DataMember]
        public decimal Total => Itens.Sum(i => i.Quantidade * i.PrecoUnitario);
    }
}
