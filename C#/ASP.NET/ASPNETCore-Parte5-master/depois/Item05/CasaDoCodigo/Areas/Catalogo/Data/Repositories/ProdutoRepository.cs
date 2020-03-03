﻿using CasaDoCodigo.Data;
using CasaDoCodigo.Areas.Catalogo.Models;
using CasaDoCodigo.Areas.Catalogo.Models.ViewModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CasaDoCodigo.Areas.Catalogo.Data.Repositories
{
    public interface IProdutoRepository
    {
        Task SaveProdutosAsync(List<Livro> livros);
        Task<IList<Produto>> GetProdutosAsync();
        Task<Produto> GetProdutoAsync(string codigo);
        Task<BuscaProdutosViewModel> GetProdutosAsync(string pesquisa);
    }

    public class ProdutoRepository : BaseRepository<Produto>, IProdutoRepository
    {
        static List<Produto> listaProdutos;
        public ProdutoRepository(IConfiguration configuration,
            CatalogoDbContext contexto) : base(configuration, contexto)
        {
        }

        public async Task<IList<Produto>> GetProdutosAsync()
        {
            return await dbSet
                .Include(prod => prod.Categoria)
                .ToListAsync();
        }

        public async Task<Produto> GetProdutoAsync(string codigo)
        {
            return await dbSet
                .Where(p => p.Codigo == codigo)
                .Include(prod => prod.Categoria)
                .SingleOrDefaultAsync();
        }

        public async Task<BuscaProdutosViewModel> GetProdutosAsync(string pesquisa)
        {
            if (listaProdutos == null)
            {
                listaProdutos =
                    await dbSet
                        .Include(prod => prod.Categoria)
                        .ToListAsync();
            }

            var resultado = listaProdutos;

            if (!string.IsNullOrEmpty(pesquisa))
            {
                pesquisa = pesquisa.ToLower();
                resultado =
                    listaProdutos
                        .Where(q =>
                        q.Nome.ToLower().Contains(pesquisa)
                        || q.Categoria.Nome.ToLower().Contains(pesquisa))
                        .ToList();
            }

            return new BuscaProdutosViewModel(resultado, pesquisa);
        }

        public async Task SaveProdutosAsync(List<Livro> livros)
        {
            await SaveCategorias(livros);

            foreach (var livro in livros)
            {
                var categoria =
                    await contexto.Set<Categoria>()
                        .SingleAsync(c => c.Nome == livro.Categoria);

                if (!await dbSet.Where(p => p.Codigo == livro.Codigo).AnyAsync())
                {
                    await dbSet.AddAsync(new Produto(livro.Codigo, livro.Nome, livro.Preco, categoria));
                }
            }
            await contexto.SaveChangesAsync();
        }

        private async Task SaveCategorias(List<Livro> livros)
        {
            var categorias =
                livros
                    .OrderBy(l => l.Categoria)
                    .Select(l => l.Categoria)
                    .Distinct();

            foreach (var nomeCategoria in categorias)
            {
                var categoriaDB =
                    await contexto.Set<Categoria>()
                    .SingleOrDefaultAsync(c => c.Nome == nomeCategoria);
                if (categoriaDB == null)
                {
                    await contexto.Set<Categoria>()
                        .AddAsync(new Categoria(nomeCategoria));
                }
            }
            await contexto.SaveChangesAsync();
        }
    }

    public class Livro
    {
        public string Codigo { get; set; }
        public string Nome { get; set; }
        public string Categoria { get; set; }
        public string Subcategoria { get; set; }
        public decimal Preco { get; set; }
    }
}
