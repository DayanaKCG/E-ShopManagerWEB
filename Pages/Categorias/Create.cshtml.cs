using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using E_ShopManagerWEB.Data;
using E_ShopManagerWEB.Models;

namespace E_ShopManagerWEB.Pages.Categorias
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
        public Categoria Categoria { get; set; } = default!;

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid || _context.Categorias == null || Categoria == null)
            {
                return Page();
            }
            _context.Categorias.Add(Categoria);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
