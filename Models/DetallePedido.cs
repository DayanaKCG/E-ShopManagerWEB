using System.ComponentModel.DataAnnotations.Schema;

namespace E_ShopManagerWEB.Models
{
	public class DetallePedido
	{
		public int Id { get; set; }
		public int IdDetalle { get; set; }// PK
		[ForeignKey("IdPedido")]
		public int IdPedido { get; set; } // FK
		public Pedido Pedido { get; set; } = default!; //Navegacion consulta
		[ForeignKey("IdProducto")]
		public int IdProducto { get; set; } //FK
		public Producto Producto { get; set; } = default!; // Navegacion conslta
		public int Cantidad { get; set; }

		[Column(TypeName = "decimal(6,2)")]
		public decimal Precio { get; set; }
	}
}
