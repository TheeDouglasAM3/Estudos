using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alura.Loja.Testes.ConsoleApp
{
    public class ProdutoDAOEntity : IProdutoDAO, IDisposable    
    {
        private LojaContext repo;

        public ProdutoDAOEntity()
        {
            repo = new LojaContext();
        }
        public void Adicionar(Produto p)
        {
            repo.Add(p);
            repo.SaveChanges();
        }

        public void Atualizar(Produto p)
        {
            repo.Update(p);
            repo.SaveChanges();
        }

        public void Dispose()
        {
            repo.Dispose();
        }

        public IList<Produto> Produtos()
        {
            return repo.Produtos.ToList();
        }

        public void Remover(Produto p)
        {
            repo.Remove(p);
            repo.SaveChanges();
        }
    }
}
