using CasaDoCodigo.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CasaDoCodigo.Areas.Catalogo.ViewComponents
{
    public class ProdutoCardViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke(Produto produto)
        {
            return View("Default", produto);
        }
    }
}
