using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Client_API.API;

namespace Client_API.Pages.ChiffreVentes
{
    public class DetailsModel : PageModel
    {
        private readonly IConstructeursAPI _context;

        public DetailsModel(IConstructeursAPI context)
        {
            _context = context;
        }

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
           
            return Page();
        }
    }
}
