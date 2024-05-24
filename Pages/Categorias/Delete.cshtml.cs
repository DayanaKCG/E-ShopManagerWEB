using E_ShopManagerWEB.Data;
using E_ShopManagerWEB.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace E_ShopManagerWEB.Pages.Categorias
{
    public class DeleteModel : PageModel
    {
        private readonly E_ShopManagerContext _context;
        public DeleteModel(E_ShopManagerContext context)
        {
            _context = context;
        }
        [BindProperty]
        public Categoria Categoria { get; set; } = default!;
        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Categorias == null)
            {
                return NotFound();
            }
            var categoria = await _context.Categorias.FirstOrDefaultAsync(m  => m.Id == id);
            if (categoria == null)
            {
                return NotFound();
            }
            else
            {
                Categoria = categoria;
            }
            return Page();
		}

        public async Task<IActionResult>OnPostAsync(int? id)
        {
            if (id == null || _context.Categorias == null)
            {
                return NotFound();
            }
            var categoria = await _context.Categorias.FindAsync(id);
            if (categoria != null)
			{
				Categoria = categoria;
				_context.Categorias.Remove(categoria);
				await _context.SaveChangesAsync();
			}
			return RedirectToPage("./Index");
		}
    }
}
