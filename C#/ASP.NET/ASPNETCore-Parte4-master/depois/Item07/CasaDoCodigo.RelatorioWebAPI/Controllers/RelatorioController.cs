using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CasaDoCodigo.RelatorioWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RelatorioController : ControllerBase
    {
        private static readonly List<string> Relatorio =
            new List<string>()
            {
                "Primeiro pedido",
                "Segundo pedido"
            };

        // GET: api/Relatorio
        [HttpGet]
        public string Get()
        {
            StringBuilder stringBuilder = new StringBuilder();
            foreach (var item in Relatorio)
            {
                stringBuilder.AppendLine(item);
            }

            return stringBuilder.ToString();
        }

        // POST: api/Relatorio
        [Authorize]
        [HttpPost]
        public void Post([FromBody] string value)
        {
            Relatorio.Add(value);
        }
    }
}
