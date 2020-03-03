using CasaDoCodigo.Models;
using Microsoft.EntityFrameworkCore;

namespace CasaDoCodigo.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Categoria>(builder =>
            {
                builder.HasKey(t => t.Id);
            });

            modelBuilder.Entity<Produto>(builder =>
            {
                builder.HasKey(t => t.Id);   
            });

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
                builder.HasOne(t => t.Produto);
            });
        }
    }
}
