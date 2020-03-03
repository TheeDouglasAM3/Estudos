using CasaDoCodigo.Areas.Catalogo.Models.ViewModels;
using CasaDoCodigo.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CasaDoCodigo.Areas.Catalogo.ViewComponents
{
    public class CarrosselViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke(Categoria categoria, IList<Produto> produtos, int tamanhoPagina)
        {
            var produtosNaCategoria =
                produtos
                .Where(p => p.Categoria.Id == categoria.Id)
                .ToList();

            int paginas = (int)Math.Ceiling((double)produtosNaCategoria.Count() / tamanhoPagina);

            return View("Default",
                new CarrosselViewModel(categoria, produtosNaCategoria, paginas, tamanhoPagina));
        }
    }
}
