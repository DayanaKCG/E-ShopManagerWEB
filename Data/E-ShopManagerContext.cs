using E_ShopManagerWEB.Models;
using Microsoft.EntityFrameworkCore;

namespace E_ShopManagerWEB.Data
{
	public class E_ShopManagerContext : DbContext
	{
		public E_ShopManagerContext(DbContextOptions options) : base(options)
		{
		}
		public DbSet<Producto> Productos { get; set; }
		public DbSet<Categoria> Categorias { get; set; }
		public DbSet<Cliente> Clientes { get; set; }
		public DbSet<Pedido> Pedidos { get; set; }
		public DbSet<DetallePedido> DetallePedidos { get; set; }

		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			optionsBuilder.UseSqlServer(
				"Server=(localdb)\\mssqllocaldb;Database=E-ShopManager;Trusted_Connection=True;");
		}


		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<Producto>()
				.HasOne(p => p.Categoria)
				.WithMany(c => c.Productos)
				.HasForeignKey(p => p.IdCategoria);

			modelBuilder.Entity<Pedido>()
				.HasOne(p => p.Cliente)
				.WithMany()
				.HasForeignKey(p => p.IdCliente);

			modelBuilder.Entity<DetallePedido>()
				.HasOne(d => d.Pedido)
				.WithMany(p => p.DetallesPedido)
				.HasForeignKey(d => d.IdPedido);

			modelBuilder.Entity<DetallePedido>()
				.HasOne(d => d.Producto)
				.WithMany()
				.HasForeignKey(d => d.IdProducto);

			// Configurar precisión y escala para las propiedades decimales
			modelBuilder.Entity<Producto>()
				.Property(p => p.Precio)
				.HasColumnType("decimal(6,2)");

			modelBuilder.Entity<Pedido>()
				.Property(p => p.Total)
				.HasColumnType("decimal(10,2)");

			modelBuilder.Entity<DetallePedido>()
				.Property(d => d.Precio)
				.HasColumnType("decimal(10,2)");

		}
	}
}