using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alura.Loja.Testes.ConsoleApp
{
    partial class Program
    {

        private static void AtualizarProdutosEntity()
        {
            //Inclui produto
            GravandoProdutosEntity();
            ListarProdutosEntity();

            //Atualiza produto
            using (var repo = new ProdutoDAOEntity())
            {
                var produto = repo.Produtos().First();
                produto.Nome = "Editado Potter";
                repo.Atualizar(produto);
            }
            ListarProdutosEntity();
        }

        private static void ExcluirProdutosEntity()
        {
            using (var repo = new ProdutoDAOEntity())
            {
                var produtos = repo.Produtos();
                if (produtos != null)
                {
                    foreach (var item in produtos)
                    {
                        repo.Remover(item);
                    }
                }
            }
        }

        private static void ListarProdutosEntity()
        {
            using (var repo = new ProdutoDAOEntity())
            {
                IList<Produto> produtos = repo.Produtos();
                Console.WriteLine($"Foram encontrados {produtos.Count} registros.");
                foreach (var item in produtos)
                {
                    Console.WriteLine(item.Nome);
                }
            }
        }

        private static void GravandoProdutosEntity()
        {
            Produto p = new Produto();
            p.Nome = "Harry Potter e a Ordem da Fênix";
            p.Categoria = "Livros";
            p.PrecoUnitario = 19.89;

            using (var context = new ProdutoDAOEntity())
            {
                context.Adicionar(p);
            }
        }

        private static void GravarUsandoAdoNet()
        {
            Produto p = new Produto();
            p.Nome = "Harry Potter e a Ordem da Fênix";
            p.Categoria = "Livros";
            p.PrecoUnitario = 19.89;

            using (var repo = new ProdutoDAO())
            {
                repo.Adicionar(p);
                var list = repo.Produtos();
                foreach (var item in list)
                {
                    Console.WriteLine(item.Nome);
                }
            }
        }
    }
}
