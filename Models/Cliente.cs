namespace E_ShopManagerWEB.Models
{
	public class Cliente
	{
		public int Id { get; set; }
		public int IdCliente { get; set; } // PK
		public string Nombre { get; set; }
		public string Apellido { get; set; }
		public string Email { get; set; }
		public string Telefono { get; set; }
		public string Direccion { get; set; }

		public ICollection<Pedido>? Pedidos { get; set; } = default!;
	}
}
