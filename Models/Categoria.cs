namespace E_ShopManagerWEB.Models
{
	public class Categoria
	{
		public int Id { get; set; }
		public int IdCategoria { get; set; }
		public string NombreCategoria { get; set; }
		public string? Descripcion { get; set; }

		public ICollection<Producto>? Productos { get; set; } = default!;
	}
}