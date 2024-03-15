using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Client_API.API;

namespace Client_API.Pages.Constructeurs
{
    public class EditModel : PageModel
    {
        private readonly IConstructeursAPI _context;

        public EditModel(IConstructeursAPI context)
        {
            _context = context;
        }

        [BindProperty]
        public Constructeur Constructeur { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var constructeur =  await _context.ConstructeursGETAsync(id.Value);
            if (constructeur == null)
            {
                return NotFound();
            }
            Constructeur = constructeur;
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
                await _context.ConstructeursPUTAsync(Constructeur.Id,Constructeur);
            }
            catch (Exception ex)
            {
                return RedirectToPage("./Index");
            }

            return RedirectToPage("./Index");
        }

       
    }
}
