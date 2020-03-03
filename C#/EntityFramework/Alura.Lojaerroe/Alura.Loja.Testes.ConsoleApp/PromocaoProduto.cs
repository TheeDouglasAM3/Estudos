namespace Alura.Loja.Testes.ConsoleApp
{
    public class PromocaoProduto
    {
        public int IdPromocao { get; set; }
        public int IdProduto { get; set; }
        public Promocao Promocao { get; set; }
        public Produto Produto { get; set; }
    }
}
