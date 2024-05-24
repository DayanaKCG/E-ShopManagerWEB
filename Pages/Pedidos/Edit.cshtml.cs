using E_ShopManagerWEB.Data;
using E_ShopManagerWEB.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace E_ShopManagerWEB.Pages.Pedidos
{
    public class EditModel : PageModel
    {
		private readonly E_ShopManagerContext _context;
		public EditModel(E_ShopManagerContext context)
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
			Pedido = pedido;
			return Page();
		}
		public async Task<IActionResult> OnPostAsync()
		{
			if (!ModelState.IsValid)
			{
				return Page();
			}
			_context.Attach(Pedido).State = EntityState.Modified;
			try
			{
				await _context.SaveChangesAsync();
			}
			catch (DbUpdateConcurrencyException)
			{
				if (!PedidoExists(Pedido.Id))
				{
					return NotFound();
				}
				else
				{
					throw;
				}
			}
			return RedirectToPage("./Index");
		}
		private bool PedidoExists(int id)
		{
			return (_context.Clientes?.Any(e => e.Id == id)).GetValueOrDefault();
		}
	}
}