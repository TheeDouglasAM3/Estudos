using CasaDoCodigo.Data;
using CasaDoCodigo.Models;
using Microsoft.Extensions.Configuration;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace CasaDoCodigo.Repositories
{
    public interface ICadastroRepository
    {
        Task<Cadastro> UpdateAsync(int cadastroId, Cadastro novoCadastro);
    }

    public class CadastroRepository : BaseRepository<Cadastro>, ICadastroRepository
    {
        public CadastroRepository(IConfiguration configuration,
            ApplicationDbContext contexto) : base(configuration, contexto)
        {
        }

        public async Task<Cadastro> UpdateAsync(int cadastroId, Cadastro novoCadastro)
        {
            var cadastroDB = dbSet.Where(c => c.Id == cadastroId)
                .SingleOrDefault();

            if (cadastroDB == null)
            {
                throw new ArgumentNullException("cadastro");
            }

            cadastroDB.Update(novoCadastro);
            await contexto.SaveChangesAsync();
            return cadastroDB;
        }
    }
}
