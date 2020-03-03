using System.Collections.Generic;

namespace Alura.Loja.Testes.ConsoleApp
{
    public class Compra
    {
        public int Id { get; internal set; }
        public int Quantidade { get; internal set; }
        public int ProdutoId { get; set; }
        public Produto Produto { get; internal set; }
        public double PrecoTotal { get; internal set; }
        public Compra()
        {
        }
    }
}