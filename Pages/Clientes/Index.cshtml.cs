using E_ShopManagerWEB.Data;
using E_ShopManagerWEB.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace E_ShopManagerWEB.Pages.Clientes
{
    public class IndexModel : PageModel
    {
		private readonly E_ShopManagerContext _context;
		public IndexModel(E_ShopManagerContext context)
		{
			_context = context;
		}

		public IList<Cliente> Clientes { get; set; } = default!;
		public async Task OnGetAsync()
		{
			if (_context.Clientes != null)
			{
				Clientes = await _context.Clientes.ToListAsync();
			}
		}
	}
}