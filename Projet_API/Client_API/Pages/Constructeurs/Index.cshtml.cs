using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Client_API.API;

namespace Client_API.Pages.Constructeurs
{
    public class IndexModel : PageModel
    {
        private readonly IConstructeursAPI _context;

        public IndexModel(IConstructeursAPI context)
        {
            _context = context;
        }

        public IList<Constructeur> Constructeur { get;set; } = default!;

        public async Task OnGetAsync()
        {
            Constructeur = (await _context.ConstructeursAllAsync()).ToList();
        }
    }
}
