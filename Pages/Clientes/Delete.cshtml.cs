using E_ShopManagerWEB.Data;
using E_ShopManagerWEB.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace E_ShopManagerWEB.Pages.Clientes
{
    public class DeleteModel : PageModel
    {
		private readonly E_ShopManagerContext _context;
		public DeleteModel(E_ShopManagerContext context)
		{
			_context = context;
		}
		[BindProperty]
		public Cliente Cliente { get; set; } = default!;
		public async Task<IActionResult> OnGetAsync(int? id)
		{
			if (id == null || _context.Clientes == null)
			{
				return NotFound();
			}
			var cliente = await _context.Clientes.FirstOrDefaultAsync(m => m.Id == id);
			if (cliente == null)
			{
				return NotFound();
			}
			else
			{
				Cliente = cliente;
			}
			return Page();
		}

		public async Task<IActionResult> OnPostAsync(int? id)
		{
			if (id == null || _context.Clientes == null)
			{
				return NotFound();
			}
			var cliente = await _context.Clientes.FindAsync(id);
			if (cliente != null)
			{
				Cliente = cliente;
				_context.Clientes.Remove(cliente);
				await _context.SaveChangesAsync();
			}
			return RedirectToPage("./Index");
		}
	}
}