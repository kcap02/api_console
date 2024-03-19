using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Client_API.API;

namespace Client_API.Pages.ChiffreVentes
{
    public class EditModel : PageModel
    {
        private readonly IConstructeursAPI _context;

        public EditModel(IConstructeursAPI context)
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

            var chiffresventes =  await _context.ChiffresVentesGETAsync(id.Value);
            if (chiffresventes == null)
            {
                return NotFound();
            }
            ChiffresVentes = chiffresventes;
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            

            try
            {
                await _context.ChiffresVentesPUTAsync(ChiffresVentes.Id,ChiffresVentes);
            }
            catch (Exception ex)
            {
                return RedirectToPage("./Index");
            }

            return RedirectToPage("./Index");
        }

        
    }
}
