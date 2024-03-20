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
    public class IndexModel : PageModel
    {
        private readonly IConstructeursAPI _context;

        public IndexModel(IConstructeursAPI context)
        {
            _context = context;
        }

        public IList<ConsoledeJeux> ConsoledeJeux { get; set; } = default!;
         public IList< Constructeur> Constructeur = new List<Constructeur>();


        public async Task OnGetAsync()
        {
            ConsoledeJeux = (await _context.ConsoledeJeuxesAllAsync()).ToList();
            
        
            foreach (var jeux in ConsoledeJeux)
            {
                Constructeur.Add(await _context.ConstructeursGETAsync(jeux.IdConstructeur));
            }
    
        }
        



    }
}
