using CasaDoCodigo.Areas.Catalogo.Models;
using CasaDoCodigo.Areas.Catalogo.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace CasaDoCodigo.Areas.Catalogo.ViewComponents
{
    public class CategoriasViewComponent : ViewComponent
    {
        private const int TamanhoPagina = 4;

        public IViewComponentResult Invoke(IList<Produto> produtos)
        {
            var categorias =
                produtos
                .Select(m => m.Categoria)
                .Distinct()
                .ToList();

            return View("Default", 
                new CategoriasViewModel(categorias, produtos, TamanhoPagina));
        }
    }
}
