using System.Threading.Tasks;
using CasaDoCodigo.Models;
using Microsoft.Extensions.Configuration;

namespace CasaDoCodigo
{
    public interface IHttpHelper
    {
        IConfiguration Configuration { get; }
        int? GetPedidoId();
        void SetPedidoId(int pedidoId);
        void ResetPedidoId();
    }
}