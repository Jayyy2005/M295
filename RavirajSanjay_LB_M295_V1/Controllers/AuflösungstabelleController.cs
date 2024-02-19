using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RavirajSanjay_LB_M295_V1.Model;
using RavirajSanjay_LB_M295_V1.Data;
using System;

namespace RavirajSanjay_LB_M295_V1.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AuflösungstabelleController : ControllerBase
    {
        private readonly AppDbContext _context;

        public AuflösungstabelleController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Auflösungstabelle>>> GetAllResolutionTables()
        {
            return await _context.Auflösungstabellen.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Auflösungstabelle>> GetResolutionTableById(int id)
        {
            var auflösungstabelle = await _context.Auflösungstabellen.FindAsync(id);

            if (auflösungstabelle == null)
            {
                return NotFound();
            }

            return auflösungstabelle;
        }

        [HttpPost]
        public async Task<ActionResult<Auflösungstabelle>> CreateResolutionTable(Auflösungstabelle auflösungstabelle)
        {
            _context.Auflösungstabellen.Add(auflösungstabelle);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetResolutionTableById), new { id = auflösungstabelle.Id }, auflösungstabelle);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateResolutionTable(int id, Auflösungstabelle auflösungstabelle)
        {
            if (id != auflösungstabelle.Id)
            {
                return BadRequest();
            }

            _context.Entry(auflösungstabelle).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_context.Auflösungstabellen.Any(e => e.Id == id))
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

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteResolutionTable(int id)
        {
            var auflösungstabelle = await _context.Auflösungstabellen.FindAsync(id);
            if (auflösungstabelle == null)
            {
                return NotFound();
            }

            _context.Auflösungstabellen.Remove(auflösungstabelle);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
