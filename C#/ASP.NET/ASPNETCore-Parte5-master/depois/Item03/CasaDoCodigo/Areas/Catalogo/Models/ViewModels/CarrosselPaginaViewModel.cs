using CasaDoCodigo.Models;
using System.Collections.Generic;

namespace CasaDoCodigo.Areas.Catalogo.Models.ViewModels
{
    public class CarrosselPaginaViewModel
    {
        public CarrosselPaginaViewModel(IList<Produto> produtos, int indice)
        {
            Produtos = produtos;
            Indice = indice;
        }

        public IList<Produto> Produtos { get; set; }
        public int Indice { get; set; }
    }
}
