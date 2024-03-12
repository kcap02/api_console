using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Projet_API.Data;
using Projet_API.Models;

namespace Projet_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ConstructeursController : ControllerBase
    {
        private readonly Projet_APIContext _context;

        public ConstructeursController(Projet_APIContext context)
        {
            _context = context;
        }

        // GET: api/Constructeurs
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Constructeur>>> GetConstructeur()
        {
            return await _context.Constructeur.ToListAsync();
        }

        // GET: api/Constructeurs/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Constructeur>> GetConstructeur(int id)
        {
            var constructeur = await _context.Constructeur.FindAsync(id);

            if (constructeur == null)
            {
                return NotFound();
            }

            return constructeur;
        }

        // PUT: api/Constructeurs/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutConstructeur(int id, Constructeur constructeur)
        {
            if (id != constructeur.Id)
            {
                return BadRequest();
            }

            _context.Entry(constructeur).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ConstructeurExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Constructeurs
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Constructeur>> PostConstructeur(Constructeur constructeur)
        {
            _context.Constructeur.Add(constructeur);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetConstructeur", new { id = constructeur.Id }, constructeur);
        }

        // DELETE: api/Constructeurs/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteConstructeur(int id)
        {
            var constructeur = await _context.Constructeur.FindAsync(id);
            if (constructeur == null)
            {
                return NotFound();
            }

            _context.Constructeur.Remove(constructeur);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ConstructeurExists(int id)
        {
            return _context.Constructeur.Any(e => e.Id == id);
        }
    }
}
