using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace E_ShopManagerWEB.Models
{
	public class Pedido
	{
		public int Id { get; set; }
		public int IdPedido { get; set; } //(PK)

		[ForeignKey("IdCliente")] //Especifica  nombre de la clase FK
		public int IdCliente { get; set; } // FK
		public Cliente Cliente { get; set; } = default!;
		public DateTime FechaPedido { get; set; }

		[Column(TypeName = "decimal(10,2)")]
		public decimal Total { get; set; }
		public EstadoPedido Estado { get; set; }
		public ICollection<DetallePedido>? DetallesPedido { get; set; } = default!;
	}
	public enum EstadoPedido
	{
		Pendiente,
		Enviado,
		Entregado
	}
}
