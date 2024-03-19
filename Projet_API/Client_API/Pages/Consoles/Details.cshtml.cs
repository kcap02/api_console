using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
//using Microsoft.EntityFrameworkCore;
using Client_API.API;

namespace Client_API.Pages.Consoles
{
    public class DetailsModel : PageModel
    {
        private readonly IConstructeursAPI _context;

        public DetailsModel(IConstructeursAPI context)
        {
            _context = context;
        }

        public ConsoledeJeux ConsoledeJeux { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            ConsoledeJeux = await _context.ConsoledeJeuxesGETAsync(id.Value);
            if (ConsoledeJeux == null)
            {
                return NotFound();
            }

            return Page();
        }
    }
}
