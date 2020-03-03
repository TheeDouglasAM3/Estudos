using CasaDoCodigo.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace CasaDoCodigo.Models
{
    [DataContract]
    public class UpdateQuantidadeResponse
    {
        public UpdateQuantidadeResponse()
        {
                
        }

        public UpdateQuantidadeResponse(ItemPedido itemPedido, CarrinhoViewModel carrinhoViewModel)
        {
            this.ItemId = itemPedido.Id;
            this.ItemQuantidade = itemPedido.Quantidade;
            this.ItemSubtotal = itemPedido.Subtotal;
            this.NumeroItens = carrinhoViewModel.Itens.Count();
            this.Total = carrinhoViewModel.Total;
        }

        [DataMember]
        public int ItemId { get; set; }
        [DataMember]
        public int ItemQuantidade { get; set; }
        [DataMember]
        public decimal ItemSubtotal { get; set; }
        [DataMember]
        public int NumeroItens { get; set; }
        [DataMember]
        public decimal Total { get; set; }
    }
}
