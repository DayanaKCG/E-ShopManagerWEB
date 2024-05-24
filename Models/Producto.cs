using System.ComponentModel.DataAnnotations.Schema;

namespace E_ShopManagerWEB.Models
{
	public class Producto
	{
		public int Id { get; set; }
		public int IdProducto { get; set; }
		public string Nombre { get; set; }
		public string Descripcion { get; set; }

		[Column(TypeName = "decimal(6,2)")]
		public decimal Precio { get; set; }

		public int Stock { get; set; }
		[ForeignKey("IdCategoria")]
		public int? IdCategoria { get; set; } // (FK)
		public Categoria? Categoria { get; set; } //= default!;
		public string ImagenUrl { get; set; }

		public ICollection<DetallePedido>? DetallePedidos { get; set; } //= default!;


	}
}
