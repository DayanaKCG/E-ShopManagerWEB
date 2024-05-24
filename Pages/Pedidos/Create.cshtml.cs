using E_ShopManagerWEB.Data;
using E_ShopManagerWEB.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace E_ShopManagerWEB.Pages.Pedidos
{
    public class CreateModel : PageModel
    {
		private readonly E_ShopManagerContext _context;
		public CreateModel(E_ShopManagerContext context)
		{
			_context = context;
		}
		public IActionResult OnGet()
		{
			return Page();
		}

		[BindProperty]
		public Pedido Pedido { get; set; } = default!;

		public async Task<IActionResult> OnPostAsync()
		{
			if (!ModelState.IsValid || _context.Pedidos == null || Pedido == null)
			{
				return Page();
			}
			_context.Pedidos.Add(Pedido);
			await _context.SaveChangesAsync();

			return RedirectToPage("./Index");
		}
	}
}