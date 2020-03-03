using CasaDoCodigo.Areas.Catalogo.Models;
using Microsoft.AspNetCore.Mvc;

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
