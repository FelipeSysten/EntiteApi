using Microsoft.EntityFrameworkCore;
using WebApplicationApi.Models;

namespace WebApplicationApi.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<ClienteModel> Clientes { get; set; }
        public DbSet<PedidoModel> Pedidos { get; set; }  // Nomenclatura ajustada
        public DbSet<ProdutoModel> Produtos { get; set; }
        public DbSet<StatusModel> Status { get; set; }  // Nomenclatura ajustada

        public DbSet<StatusModel> Statuses { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ClienteModel>().HasKey(c => c.IdCliente);
            modelBuilder.Entity<PedidoModel>().HasKey(p => p.IdPedido);
            modelBuilder.Entity<ProdutoModel>().HasKey(prod => prod.IdProduto);
            modelBuilder.Entity<StatusModel>().HasKey(s => s.IdStatus);

            // Configura o relacionamento muitos-para-muitos entre Pedido e Produto
            modelBuilder.Entity<PedidoModel>()
                .HasMany(p => p.Produtos)
                .WithMany(prod => prod.Pedidos);

            base.OnModelCreating(modelBuilder);
        }
    }
}
