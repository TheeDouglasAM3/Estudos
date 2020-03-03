using CasaDoCodigo.Models;
using Microsoft.EntityFrameworkCore;

namespace CasaDoCodigo.Data
{
    //PARA CRIAR UMA MIGRAÇÃO:
    //Add-Migration "ModeloSemProduto" -Context ApplicationDbContext
    //PARA EXECUTAR A MIGRAÇÃO:
    //Update-Database -verbose -Context ApplicationDbContext
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Pedido>(builder =>
            {
                builder.HasKey(t => t.Id);
                builder.HasMany(t => t.Itens).WithOne(t => t.Pedido);
                builder.HasOne(t => t.Cadastro)
                    .WithOne(t => t.Pedido)
                    .IsRequired();
            });

            modelBuilder.Entity<ItemPedido>(builder =>
            {
                builder.HasKey(t => t.Id);
                builder.HasOne(t => t.Pedido);
            });
        }
    }
}
