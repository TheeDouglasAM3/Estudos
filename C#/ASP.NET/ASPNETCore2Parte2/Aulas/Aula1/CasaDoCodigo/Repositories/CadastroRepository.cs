using CasaDoCodigo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CasaDoCodigo.Repositories
{
    public class CadastroRepository : BaseRepository<Cadastro>, ICadastroRepository
    {
        public CadastroRepository(ApplicationContext contexto) : base(contexto)
        {
        }

        public Cadastro Update(int idCadastro, Cadastro novoCadastro)
        {
            var cadastroDB = dbSet
                .Where(c => c.Id == idCadastro)
                .SingleOrDefault();

            if (cadastroDB == null)
                throw new ArgumentNullException("cadastro");

            cadastroDB.Update(novoCadastro);
            contexto.SaveChanges();
            return cadastroDB;
        }
    }
}
