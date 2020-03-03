using CasaDoCodigo.Models;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace CasaDoCodigo
{
    public interface IRelatorioHelper
    {
        Task GerarRelatorio(Pedido pedido);
    }

    public class RelatorioHelper : IRelatorioHelper
    {
        private const string RelativeUri = "api/relatorio";
        private readonly IConfiguration configuration;

        //PROBLEMA: NÃO DETECTA MUDANÇAS NO DNS
        //private static HttpClient httpClient;

        private readonly HttpClient httpClient;

        public RelatorioHelper(IConfiguration configuration,
            HttpClient httpClient)
        {
            this.configuration = configuration;
            this.httpClient = httpClient;
        }

        public async Task GerarRelatorio(Pedido pedido)
        {
            string linhaRelatorio = await GetLinhaRelatorio(pedido);

            //PROBLEMA: EXAUSTÃO DE SOCKET
            //using (HttpClient httpClient = new HttpClient())


            //using (HttpClient httpClient = HttpClientFactory.Create())
            //{
                //o texto do conteúdo (JSON)
                var json = JsonConvert.SerializeObject(linhaRelatorio);
                //o objeto HttpContent que empacota o texto (application/json)
                HttpContent httpContent = new StringContent(json, Encoding.UTF8, "application/json");
                //URI = identificador universal de recurso

                //endereço base: http://localhost:5002
                //endereço relativo: api/relatorio

                Uri baseUri = new Uri(configuration["RelatorioWebAPIURL"]);
                Uri uri = new Uri(baseUri, RelativeUri);
                HttpResponseMessage httpResponseMessage =
                    await httpClient.PostAsync(uri, httpContent);

                if (!httpResponseMessage.IsSuccessStatusCode)
                {
                    throw new ApplicationException(httpResponseMessage.ReasonPhrase);
                }
            //}
        }

        private async Task<string> GetLinhaRelatorio(Pedido pedido)
        {
            StringBuilder sb = new StringBuilder();
            string templatePedido =
                    await System.IO.File.ReadAllTextAsync("TemplatePedido.txt");

            string templateItemPedido =
                await System.IO.File.ReadAllTextAsync("TemplateItemPedido.txt");

            string linhaPedido =
                string.Format(templatePedido,
                    pedido.Id,
                    pedido.Cadastro.Nome,
                    pedido.Cadastro.Endereco,
                    pedido.Cadastro.Complemento,
                    pedido.Cadastro.Bairro,
                    pedido.Cadastro.Municipio,
                    pedido.Cadastro.UF,
                    pedido.Cadastro.Telefone,
                    pedido.Cadastro.Email,
                    pedido.Itens.Sum(i => i.Subtotal));

            sb.AppendLine(linhaPedido);

            foreach (var i in pedido.Itens)
            {
                string linhaItemPedido =
                    string.Format(
                        templateItemPedido,
                        i.Produto.Codigo,
                        i.PrecoUnitario,
                        i.Produto.Nome,
                        i.Quantidade,
                        i.Subtotal);

                sb.AppendLine(linhaItemPedido);
            }
            sb.AppendLine($@"=============================================");

            return sb.ToString();
        }
    }
}