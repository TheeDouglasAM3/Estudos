using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ByteBank.SistemaAgencia
{
    public class ExtratorValorDeArgumentoURL
    {
        public string URL { get; }
        private readonly string _argumentos;
        public ExtratorValorDeArgumentoURL(string url)
        {

            if (String.IsNullOrEmpty(url))
                throw new ArgumentException("Argumento nao pode ser nulo ou vazio.", nameof(url));

            URL = url;
            int indexInterrogacao = url.IndexOf('?');
            _argumentos = url.Substring(++indexInterrogacao);
        }

        public string GetValor(string nomeParametro)
        {
            nomeParametro = nomeParametro.ToLower();
            string argumentoLower = _argumentos.ToLower();

            string termo = nomeParametro + "=";
            int indexTermo = argumentoLower.IndexOf(termo);

            string resultado = _argumentos.Substring(indexTermo + termo.Length);
            int indexEComercial = resultado.IndexOf('&');

            if (indexEComercial != -1)
                return resultado.Remove(indexEComercial);

            return resultado;

        }
    }
}
