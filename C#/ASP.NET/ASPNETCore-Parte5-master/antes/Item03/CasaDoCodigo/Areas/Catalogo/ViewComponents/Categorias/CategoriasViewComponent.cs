using CasaDoCodigo.Areas.Catalogo.Models.ViewModels;
using CasaDoCodigo.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CasaDoCodigo.Areas.Catalogo.ViewComponents.Categorias
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
