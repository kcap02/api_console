using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Client_API.API;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Client_API.API;

namespace Client_API.Pages.Constructeurs
{
    public class DeleteModel : PageModel
    {
        private readonly IConstructeursAPI _context;

        public DeleteModel(IConstructeursAPI context)
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

            Constructeur = await _context.ConstructeursGETAsync(id.Value);

            if (Constructeur == null)
            {
                return NotFound();
            }
            else
            {
                Constructeur = Constructeur;
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
                await _context.ConstructeursDELETEAsync(id.Value);
            }
            catch (Exception ex) 
            {
                return RedirectToPage("./Index");
            }
               
            

            return RedirectToPage("./Index");
        }
    }
}
