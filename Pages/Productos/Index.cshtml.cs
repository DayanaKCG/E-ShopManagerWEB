using E_ShopManagerWEB.Data;
using E_ShopManagerWEB.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace E_ShopManagerWEB.Pages.Productos
{
    public class IndexModel : PageModel
    {
        private readonly E_ShopManagerContext _context;
        public IndexModel(E_ShopManagerContext context)
        {
            _context = context;
        }

        public IList<Producto> Productos { get; set; } = default!;
        public async Task OnGetAsync()
        {
            if (_context.Productos != null)
            {
                Productos = await _context.Productos.ToListAsync();
            }
        }
    }
}
