﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Client_API.API;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
///using Microsoft.EntityFrameworkCore;
using Client_API.API;

namespace Client_API.Pages.Consoles
{
    public class DeleteModel : PageModel
    {
        private readonly IConstructeursAPI _context;

        public DeleteModel(IConstructeursAPI context)
        {
            _context = context;
        }

        [BindProperty]
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
            else
            {
                ConsoledeJeux = ConsoledeJeux;
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
                await _context.ConsoledeJeuxesDELETEAsync(id.Value);
            }
            catch (Exception ex)
            {
                return RedirectToPage("./Index");
            }



            return RedirectToPage("./Index");
        }
    }
}
