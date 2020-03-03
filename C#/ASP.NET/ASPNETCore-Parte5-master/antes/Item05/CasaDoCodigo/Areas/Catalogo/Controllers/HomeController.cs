using System.Threading.Tasks;
using CasaDoCodigo.Areas.Catalogo.Data.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace CasaDoCodigo.MVC.Areas.Catalogo.Controllers
{
    [Area("Catalogo")]
    public class HomeController : Controller
    {
        private readonly IProdutoRepository produtoRepository;

        public HomeController(IProdutoRepository produtoRepository)
        {
            this.produtoRepository = produtoRepository;
        }

        public async Task<IActionResult> Index(string pesquisa)
        {
            return View(await produtoRepository.GetProdutosAsync(pesquisa));
        }

    }
}