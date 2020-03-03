using CasaDoCodigo.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CasaDoCodigo.Models.Responses
{
    public class UpdateQuantidadeResponse
    {
        public UpdateQuantidadeResponse(ItemPedido itemPedido, CarrinhoViewModel carrinhoViewModel)
        {
            this.itemPedido = itemPedido;
            this.carrinhoViewModel = carrinhoViewModel;
        }

        public ItemPedido itemPedido { get; }
        public CarrinhoViewModel carrinhoViewModel { get; }
    }
}
