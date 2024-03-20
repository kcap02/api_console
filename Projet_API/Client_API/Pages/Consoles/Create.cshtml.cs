using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Client_API.API;

namespace Client_API.Pages.Consoles
{
    public class CreateModel : PageModel
    {
        private readonly IConstructeursAPI _context;

        public CreateModel(IConstructeursAPI context)
        {
            _context = context;
        }

        
        [BindProperty]
        public ConsoledeJeux ConsoledeJeux { get; set; } = default!;
        public IList <Constructeur> Constructeurs { get; set; } = default!;

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD



        public async Task OnGetAsync()
        {
            Constructeurs = (await _context.ConstructeursAllAsync()).ToList();
            
        
    
        }
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                int selectedIdConstructeur = ConsoledeJeux.IdConstructeur;
                return Page();
            }

            try
            {
                await _context.ConsoledeJeuxesPOSTAsync(ConsoledeJeux);
            }

            catch (Exception ex)
            {
                return RedirectToPage("./Index");
            }
            return RedirectToPage("./Index");

        }
    }
}
