using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;

namespace CasaDoCodigo
{
    public interface IDataService
    {
        Task InicializaDBAsync(IServiceProvider provider);
    }
}