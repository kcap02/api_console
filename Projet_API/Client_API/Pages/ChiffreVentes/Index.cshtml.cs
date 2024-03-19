using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Client_API.API;


namespace Client_API.Pages.ChiffreVentes
{
    public class IndexModel : PageModel
    {
        private readonly IConstructeursAPI _context;

        public IndexModel(IConstructeursAPI context)
        {
            _context = context;
        }

        public IList<ChiffresVentes> ChiffresVentes { get;set; } = default!;

        public async Task OnGetAsync()
        {
            ChiffresVentes = (await _context.ChiffresVentesAllAsync()).ToList();
        }
    }
}
