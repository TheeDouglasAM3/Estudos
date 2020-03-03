using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CasaDoCodigo.Areas.Identity.Data;
using CasaDoCodigo.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CasaDoCodigo.Areas.Cadastro.Controllers
{
    [Area("Cadastro")]
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

        // GET: /<controller>/
        [Authorize]
        public async Task<IActionResult> Index()
        {
            var pedido = await pedidoRepository.GetPedidoAsync();

            if (pedido == null)
            {
                return Redirect("/");
            }

            var usuario = await userManager.GetUserAsync(this.User);

            pedido.Cadastro.Email = usuario.Email;
            pedido.Cadastro.Telefone = usuario.Telefone;
            pedido.Cadastro.Nome = usuario.Nome;
            pedido.Cadastro.Endereco = usuario.Endereco;
            pedido.Cadastro.Complemento = usuario.Complemento;
            pedido.Cadastro.Bairro = usuario.Bairro;
            pedido.Cadastro.Municipio = usuario.Municipio;
            pedido.Cadastro.UF = usuario.UF;
            pedido.Cadastro.CEP = usuario.CEP;

            return View(pedido.Cadastro);
        }

    }
}
