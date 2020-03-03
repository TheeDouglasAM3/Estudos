using CasaDoCodigo.Models;
using CasaDoCodigo.Models.ViewModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CasaDoCodigo.Repositories
{
    public interface IProdutoRepository
    {
        Task SaveProdutosAsync(List<Livro> livros);
        Task<IList<Produto>> GetProdutosAsync();
        Task<BuscaProdutosViewModel> GetProdutosAsync(string pesquisa);
    }

    public class ProdutoRepository : BaseRepository<Produto>, IProdutoRepository
    {
        public ProdutoRepository(IConfiguration configuration,
            ApplicationContext contexto) : base(configuration, contexto)
        {
        }

        public async Task<IList<Produto>> GetProdutosAsync()
        {
            return await dbSet
                .Include(prod => prod.Categoria)
                .ToListAsync();
        }

        public async Task<BuscaProdutosViewModel> GetProdutosAsync(string pesquisa)
        {
            IQueryable<Produto> query = dbSet;

            if (!string.IsNullOrEmpty(pesquisa))
            {
                query = query.Where(q => q.Nome.Contains(pesquisa));
            }

            query = query
                .Include(prod => prod.Categoria);

            return new BuscaProdutosViewModel(await query.ToListAsync(), pesquisa);
        }

        //MELHORIA: 1) Métodos assíncronos
        //Para saber mais: C#: Paralelismo no mundo rea
        //https://cursos.alura.com.br/course/csharp-paralelismo-no-mundo-real/task/27900
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
