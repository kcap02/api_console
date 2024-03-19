using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Client_API.API;

namespace Client_API.Pages.ChiffreVentes
{
    public class DeleteModel : PageModel
    {
        private readonly IConstructeursAPI _context;

        public DeleteModel(IConstructeursAPI context)
        {
            _context = context;
        }

        [BindProperty]
        public ChiffresVentes ChiffresVentes { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            ChiffresVentes = await _context.ChiffresVentesGETAsync(id.Value);

            if (ChiffresVentes == null)
            {
                return NotFound();
            }
            else
            {
                ChiffresVentes = ChiffresVentes;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            try
            {
                await _context.ChiffresVentesDELETEAsync(id.Value);
            }
            catch(Exception ex)
            {
                return RedirectToPage("./Index");
            }
            

            return RedirectToPage("./Index");
        }
    }
}
