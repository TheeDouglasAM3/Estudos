using CasaDoCodigo.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;

namespace CasaDoCodigo
{
    public class HttpHelper : IHttpHelper
    {
        private readonly IHttpContextAccessor contextAccessor;

        public IConfiguration Configuration { get; }

        public HttpHelper(IHttpContextAccessor contextAccessor
            , IConfiguration configuration)
        {
            this.contextAccessor = contextAccessor;
            Configuration = configuration;
        }

        public int? GetPedidoId()
        {
            return contextAccessor.HttpContext.Session.GetInt32($"pedidoId_{GetClienteId()}");
        }

        public void SetPedidoId(int pedidoId)
        {
            contextAccessor.HttpContext.Session.SetInt32($"pedidoId_{GetClienteId()}", pedidoId);
        }

        public void ResetPedidoId()
        {
            contextAccessor.HttpContext.Session.Remove($"pedidoId_{GetClienteId()}");
        }

        private string GetClienteId()
        {
            var claimsPrincipal = contextAccessor.HttpContext.User;
            return claimsPrincipal.FindFirst("sub")?.Value;
        }
    }
}
