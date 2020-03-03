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
        private static void TestandoMudancaEstado()
        {
            using (var contexto = new LojaContext())
            {
                //mostra o SQL puro no console
                var serviceProvider = contexto.GetInfrastructure<IServiceProvider>();
                var loggerFactory = serviceProvider.GetService<ILoggerFactory>();
                loggerFactory.AddProvider(SqlLoggerProvider.Create());

                var produtos = contexto.Produtos.ToList();
                ExibeEntries(contexto.ChangeTracker.Entries());

                //var p1 = produtos.Last();
                //p1.Nome = "007 Filme";

                var newProduto = new Produto()
                {
                    Nome = "DVD BlueRay",
                    Categoria = "Filme",
                    PrecoUnitario = 400
                };
                contexto.Produtos.Add(newProduto);
                ExibeEntries(contexto.ChangeTracker.Entries());

                contexto.Produtos.Remove(newProduto);
                ExibeEntries(contexto.ChangeTracker.Entries());

                //contexto.SaveChanges();

                var entry = contexto.Entry(newProduto);
                Console.WriteLine($"\n\n{entry.Entity.ToString()} - {entry.State}");
            }
        }

        private static void ExibeEntries(IEnumerable<EntityEntry> entries)
        {
            Console.WriteLine("=================");
            foreach (var e in entries)
            {
                Console.WriteLine($"{e.Entity.ToString()} - {e.State}");
            }
        }
    }
}
