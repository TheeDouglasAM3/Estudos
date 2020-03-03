using CasaDoCodigo.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace CasaDoCodigo.Repositories
{
    public abstract class BaseRepository<T> where T : BaseModel
    {
        protected readonly IConfiguration configuration;
        protected readonly ApplicationContext contexto;
        protected readonly DbSet<T> dbSet;

        public BaseRepository(IConfiguration configuration,
            ApplicationContext contexto)
        {
            this.configuration = configuration;
            this.contexto = contexto;
            dbSet = contexto.Set<T>();
        }
    }
}
