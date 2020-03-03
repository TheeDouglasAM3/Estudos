using System.Threading.Tasks;
using CasaDoCodigo.Areas.Identity.Data;
using CasaDoCodigo.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CasaDoCodigo.Areas.Pedido.Controllers
{
    [Area("Pedido")]
    public class HomeController : Controller
    {
        private readonly IPedidoRepository pedidoRepository;
        private readonly UserManager<AppIdentityUser> userManager;

        public HomeController(IPedidoRepository pedidoRepository,
            UserManager<AppIdentityUser> userManager)
        {
            this.pedidoRepository = pedidoRepository;
            this.userManager = userManager;
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public async Task<IActionResult> Index(CasaDoCodigo.Models.Cadastro cadastro)
        {
            if (ModelState.IsValid)
            {
                var usuario = await userManager.GetUserAsync(this.User);

                usuario.Email = cadastro.Email;
                usuario.Telefone = cadastro.Telefone;
                usuario.Nome = cadastro.Nome;
                usuario.Endereco = cadastro.Endereco;
                usuario.Complemento = cadastro.Complemento;
                usuario.Bairro = cadastro.Bairro;
                usuario.Municipio = cadastro.Municipio;
                usuario.UF = cadastro.UF;
                usuario.CEP = cadastro.CEP;

                await userManager.UpdateAsync(usuario);

                return View(await pedidoRepository.UpdateCadastroAsync(cadastro));
            }
            return Redirect("/Cadastro");
        }
    }

}
