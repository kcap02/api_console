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
    public class CreateModel : PageModel
    {
        private readonly IConstructeursAPI _context;

        public CreateModel(IConstructeursAPI context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public ChiffresVentes ChiffresVentes { get; set; } = default!;

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            try
            {
                await _context.ChiffresVentesPOSTAsync(ChiffresVentes);
            }

            catch(Exception ex)
            {
                return RedirectToPage("./Index");
            }
            

            return RedirectToPage("./Index");
        }
    }
}
