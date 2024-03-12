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
    public class ConsoledeJeuxesController : ControllerBase
    {
        private readonly Projet_APIContext _context;

        public ConsoledeJeuxesController(Projet_APIContext context)
        {
            _context = context;
        }

        // GET: api/ConsoledeJeuxes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ConsoledeJeux>>> GetConsole()
        {
            return await _context.Console.ToListAsync();
        }

        // GET: api/ConsoledeJeuxes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ConsoledeJeux>> GetConsoledeJeux(int id)
        {
            var consoledeJeux = await _context.Console.FindAsync(id);

            if (consoledeJeux == null)
            {
                return NotFound();
            }

            return consoledeJeux;
        }

        // PUT: api/ConsoledeJeuxes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutConsoledeJeux(int id, ConsoledeJeux consoledeJeux)
        {
            if (id != consoledeJeux.Id)
            {
                return BadRequest();
            }

            _context.Entry(consoledeJeux).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ConsoledeJeuxExists(id))
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

        // POST: api/ConsoledeJeuxes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ConsoledeJeux>> PostConsoledeJeux(ConsoledeJeux consoledeJeux)
        {
            _context.Console.Add(consoledeJeux);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetConsoledeJeux", new { id = consoledeJeux.Id }, consoledeJeux);
        }

        // DELETE: api/ConsoledeJeuxes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteConsoledeJeux(int id)
        {
            var consoledeJeux = await _context.Console.FindAsync(id);
            if (consoledeJeux == null)
            {
                return NotFound();
            }

            _context.Console.Remove(consoledeJeux);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ConsoledeJeuxExists(int id)
        {
            return _context.Console.Any(e => e.Id == id);
        }
    }
}
