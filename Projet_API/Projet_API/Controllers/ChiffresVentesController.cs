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
    public class ChiffresVentesController : ControllerBase
    {
        private readonly Projet_APIContext _context;

        public ChiffresVentesController(Projet_APIContext context)
        {
            _context = context;
        }

        // GET: api/ChiffresVentes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ChiffresVentes>>> GetChiffresVentes()
        {
            return await _context.ChiffresVentes.ToListAsync();
        }

        // GET: api/ChiffresVentes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ChiffresVentes>> GetChiffresVentes(int id)
        {
            var chiffresVentes = await _context.ChiffresVentes.FindAsync(id);

            if (chiffresVentes == null)
            {
                return NotFound();
            }

            return chiffresVentes;
        }

        // PUT: api/ChiffresVentes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutChiffresVentes(int id, ChiffresVentes chiffresVentes)
        {
            if (id != chiffresVentes.Id)
            {
                return BadRequest();
            }

            _context.Entry(chiffresVentes).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ChiffresVentesExists(id))
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

        // POST: api/ChiffresVentes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ChiffresVentes>> PostChiffresVentes(ChiffresVentes chiffresVentes)
        {
            _context.ChiffresVentes.Add(chiffresVentes);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetChiffresVentes", new { id = chiffresVentes.Id }, chiffresVentes);
        }

        // DELETE: api/ChiffresVentes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteChiffresVentes(int id)
        {
            var chiffresVentes = await _context.ChiffresVentes.FindAsync(id);
            if (chiffresVentes == null)
            {
                return NotFound();
            }

            _context.ChiffresVentes.Remove(chiffresVentes);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ChiffresVentesExists(int id)
        {
            return _context.ChiffresVentes.Any(e => e.Id == id);
        }
    }
}
