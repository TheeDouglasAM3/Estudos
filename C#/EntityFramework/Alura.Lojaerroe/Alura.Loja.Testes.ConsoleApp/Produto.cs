using System.Collections.Generic;

namespace Alura.Loja.Testes.ConsoleApp
{
    public class Produto
    {
        public int Id { get; internal set; }
        public string Nome { get; internal set; }
        public string Categoria { get; internal set; }
        public double PrecoUnitario { get; internal set; }
        public string Unidade { get; internal set; }
        public IList<PromocaoProduto> Promocoes { get; set; }

        /// <summary>
        ///     Contrutor para a criação de um produto com todas as propriedades preenchidas
        /// </summary>
        /// <param name="nome">Nome do produto</param>
        /// <param name="categoria">Categoria do produto (vestuário, alimento, elotrodoméstico...)</param>
        /// <param name="precoUnitario">Preço individual do produto</param>
        /// <param name="unidade">Nome da unidade do produto (un, cm, ml...)</param>
        public Produto(string nome, string categoria, double precoUnitario, string unidade)
        {
            Nome = nome;
            Categoria = categoria;
            PrecoUnitario = precoUnitario;
            Unidade = unidade;
        }

        public Produto()
        {

        }

        public override string ToString()
        {
            return $"Produto : {Id}, {Nome}, {Categoria}, {PrecoUnitario}";
        }
    }
}