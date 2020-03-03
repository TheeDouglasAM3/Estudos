using CasaDoCodigo.Areas.Catalogo.Models;
using CasaDoCodigo.Areas.Catalogo.Data.Repositories;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace CasaDoCodigo.Areas.Catalogo.Data
{
    //PARA CRIAR UMA MIGRAÇÃO:
    //Add-Migration "AreaCatalogo" -Context CatalogoDbContext -o "Areas/Catalogo/Data/Migrations"
    //PARA EXECUTAR A MIGRAÇÃO:
    //Update-Database -verbose -Context CatalogoDbContext
    public class CatalogoDbContext : DbContext
    {
        public CatalogoDbContext(DbContextOptions<CatalogoDbContext> options)
            : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            var produtos = GetProdutos();
            var categorias = 
                produtos.Select(p => p.Categoria).Distinct();

            modelBuilder.Entity<Categoria>(b =>
            {
                b.HasKey(t => t.Id);
                b.HasData(categorias); //propagação ou "seeding"
            });

            modelBuilder.Entity<Produto>(b =>
            {
                b.HasKey(t => t.Id);
                b.HasData(produtos
                    .Select(p =>
                    new
                    {
                        p.Id,
                        p.Codigo,
                        p.Nome,
                        p.Preco,
                        CategoriaId = p.Categoria.Id
                    }));
            });
        }

        private List<Livro> GetLivros()
        {
            var json = File.ReadAllText("data/livros.json");
            return JsonConvert.DeserializeObject<List<Livro>>(json);
        }

        private List<Produto> GetProdutos()
        {
            var livros = GetLivros();

            var categorias = livros
                .Select(l => l.Categoria) //projeção ou transformação
                .Distinct()
                .Select((nomeCategoria, i) =>
                {
                    var categoria = new Categoria(nomeCategoria);
                    categoria.Id = i + 1;
                    return categoria;
                });

            var produtos =
                (from livro in livros
                 join categoria in categorias
                     on livro.Categoria equals categoria.Nome
                 select new Produto(livro.Codigo, livro.Nome, livro.Preco, categoria))
                .Select((produto, i) =>
                {
                    produto.Id = i + 1;
                    return produto;
                })
                 .ToList();

            return produtos;
        }
    }
}
