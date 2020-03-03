using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alura.Loja.Testes.ConsoleApp
{
    partial class Program
    {
        static void Main(string[] args)
        {
            var promocaoDePascoa = new Promocao();
            promocaoDePascoa.Descricao = "Feliz Páscoa";
            promocaoDePascoa.DataInicio = DateTime.Now;
            promocaoDePascoa.DataTermino = DateTime.Now.AddMonths(3);
            promocaoDePascoa.IncluirProduto(new Produto("Caixa de Bombom", "Alimento", 10.0, "g"));
            promocaoDePascoa.IncluirProduto(new Produto("Ovo de páscoa", "Alimento", 25.0, "g"));
            promocaoDePascoa.IncluirProduto(new Produto("Coelho de pelúcia", "Brinquedo", 12.5, "un"));

            foreach (var item in promocaoDePascoa.Produtos)
            {
                Console.WriteLine(item.IdProduto);
            }
            Console.WriteLine(promocaoDePascoa.Id);

            using (var contexto = new LojaContext())
            {
                var serviceProvider = contexto.GetInfrastructure<IServiceProvider>();
                var loggerFactory = serviceProvider.GetService<ILoggerFactory>();
                loggerFactory.AddProvider(SqlLoggerProvider.Create());

                contexto.Promocoes.Add(promocaoDePascoa);
                //ExibeEntries(contexto.ChangeTracker.Entries());

            }
        }

        static void AdicionandoCompra()
        {
            //comprar Pão Francês
            var paoFrances = new Produto("Pão Francês", "alimento", 0.4, "un");

            var compra = new Compra();
            compra.Quantidade = 6;
            compra.Produto = paoFrances;
            compra.PrecoTotal = paoFrances.PrecoUnitario * compra.Quantidade;

            using (var contexto = new LojaContext())
            {
                contexto.Compras.Add(compra);
                contexto.SaveChanges();
            }
        }

    }
}
