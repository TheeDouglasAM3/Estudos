using CasaDoCodigo.Models;
using CasaDoCodigo.Repositories;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace CasaDoCodigo.Areas.Catalogo.Data
{
    public class CatalogoDbContext : DbContext
    {
        public CatalogoDbContext(DbContextOptions options) 
            : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            var produtos = GetProdutos();
            var categorias = produtos
                .Select(p => p.Categoria)
                .Distinct();

            modelBuilder.Entity<Categoria>(b =>
            {
                b.HasKey(t => t.Id);
                b.HasData(categorias); //seeding
            });

            modelBuilder.Entity<Produto>(b =>
            {
                b.HasKey(t => t.Id);
                b.HasData(produtos
                    .Select(p => 
                    new {
                        p.Id,
                        p.Codigo,
                        p.Nome,
                        p.Preco,
                        CategoriaId = p.Categoria.Id
                    })); //seeding
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
                .Select(l => l.Categoria) //projecao, transformacao
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
