using CasaDoCodigo.Areas.Catalogo.Data.Repositories;
using CasaDoCodigo.Areas.Identity.Data;
using CasaDoCodigo.Data;
using CasaDoCodigo.Models;
using CasaDoCodigo.Models.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace CasaDoCodigo.Repositories
{
    public interface IPedidoRepository
    {
        Task<Pedido> GetPedidoAsync();
        Task AddItemAsync(string codigo);
        Task<UpdateQuantidadeResponse> UpdateQuantidadeAsync(ItemPedido itemPedido);
        Task<Pedido> UpdateCadastroAsync(Cadastro cadastro);
    }

    public class PedidoRepository : BaseRepository<Pedido>, IPedidoRepository
    {
        private readonly IHttpContextAccessor contextAccessor;
        private readonly UserManager<AppIdentityUser> userManager;
        private readonly IHttpHelper httpHelper;
        private readonly ICadastroRepository cadastroRepository;
        private readonly IProdutoRepository produtoRepository;

        public PedidoRepository(IConfiguration configuration,
            ApplicationDbContext contexto,
            IHttpContextAccessor contextAccessor,
            UserManager<AppIdentityUser> userManager,
            IHttpHelper sessionHelper,
            ICadastroRepository cadastroRepository,
            IProdutoRepository produtoRepository) : base(configuration, contexto)
        {
            this.contextAccessor = contextAccessor;
            this.userManager = userManager;
            this.httpHelper = sessionHelper;
            this.cadastroRepository = cadastroRepository;
            this.produtoRepository = produtoRepository;
        }

        public async Task AddItemAsync(string codigo)
        {
            var produto = await produtoRepository.GetProdutoAsync(codigo);

            if (produto == null)
            {
                throw new ArgumentException("Produto não encontrado");
            }

            var pedido = await GetPedidoAsync();

            var itemPedido = await
                                contexto.Set<ItemPedido>()
                                .Where(i => i.ProdutoCodigo == codigo
                                        && i.Pedido.Id == pedido.Id)
                                .SingleOrDefaultAsync();

            if (itemPedido == null)
            {
                itemPedido = new ItemPedido(pedido, produto.Codigo, produto.Nome, 1, produto.Preco);
                await
                    contexto.Set<ItemPedido>()
                    .AddAsync(itemPedido);

                await contexto.SaveChangesAsync();
            }
        }

        public async Task<Pedido> GetPedidoAsync()
        {
            var pedidoId = httpHelper.GetPedidoId();
            var pedido =
                await dbSet
                .Include(p => p.Itens)
                .Include(p => p.Cadastro)
                .Where(p => p.Id == pedidoId)
                .SingleOrDefaultAsync();

            if (pedido == null)
            {
                var claimsPrincipal = contextAccessor.HttpContext.User;
                var clienteId = userManager.GetUserId(claimsPrincipal);

                pedido = new Pedido(clienteId);
                await dbSet.AddAsync(pedido);
                await contexto.SaveChangesAsync();
                httpHelper.SetPedidoId(pedido.Id);
            }

            return pedido;
        }

        public async Task<UpdateQuantidadeResponse> UpdateQuantidadeAsync(ItemPedido itemPedido)
        {
            var itemPedidoDB = await GetItemPedidoAsync(itemPedido.Id);

            if (itemPedidoDB != null)
            {
                itemPedidoDB.AtualizaQuantidade(itemPedido.Quantidade);

                if (itemPedido.Quantidade == 0)
                {
                    await RemoveItemPedidoAsync(itemPedido.Id);
                }

                await contexto.SaveChangesAsync();

                var pedido = await GetPedidoAsync();
                var carrinhoViewModel = new CarrinhoViewModel(pedido.Itens);

                return new UpdateQuantidadeResponse(itemPedidoDB, carrinhoViewModel);
            }

            throw new ArgumentException("ItemPedido não encontrado");
        }

        public async Task<Pedido> UpdateCadastroAsync(Cadastro cadastro)
        {
            var pedido = await GetPedidoAsync();
            await cadastroRepository.UpdateAsync(pedido.Cadastro.Id, cadastro);
            httpHelper.ResetPedidoId();
            return pedido;
        }

        private async Task<ItemPedido> GetItemPedidoAsync(int itemPedidoId)
        {
            return
            await contexto.Set<ItemPedido>()
                .Where(ip => ip.Id == itemPedidoId)
                .SingleOrDefaultAsync();
        }

        private async Task RemoveItemPedidoAsync(int itemPedidoId)
        {
            contexto.Set<ItemPedido>()
                .Remove(await GetItemPedidoAsync(itemPedidoId));
        }
    }
}