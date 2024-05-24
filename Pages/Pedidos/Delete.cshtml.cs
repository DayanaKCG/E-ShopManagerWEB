using E_ShopManagerWEB.Data;
using E_ShopManagerWEB.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace E_ShopManagerWEB.Pages.Pedidos
{
    public class DeleteModel : PageModel
    {
		private readonly E_ShopManagerContext _context;
		public DeleteModel(E_ShopManagerContext context)
		{
			_context = context;
		}
		[BindProperty]
		public Pedido Pedido { get; set; } = default!;
		public async Task<IActionResult> OnGetAsync(int? id)
		{
			if (id == null || _context.Pedidos == null)
			{
				return NotFound();
			}
			var pedido = await _context.Pedidos.FirstOrDefaultAsync(m => m.Id == id);
			if (pedido == null)
			{
				return NotFound();
			}
			else
			{
				Pedido = pedido;
			}
			return Page();
		}

		public async Task<IActionResult> OnPostAsync(int? id)
		{
			if (id == null || _context.Pedidos == null)
			{
				return NotFound();
			}
			var pedido = await _context.Pedidos.FindAsync(id);
			if (pedido != null)
			{
				Pedido = pedido;
				_context.Pedidos.Remove(pedido);
				await _context.SaveChangesAsync();
			}
			return RedirectToPage("./Index");
		}
	}
}