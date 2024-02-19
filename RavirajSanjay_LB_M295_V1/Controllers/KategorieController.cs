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
    public class KategorieController : ControllerBase
    {
        private readonly AppDbContext _context;

        public KategorieController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Kategorie>>> GetAllCategories()
        {
            return await _context.Kategorien.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Kategorie>> GetCategoryById(int id)
        {
            var kategorie = await _context.Kategorien.FindAsync(id);

            if (kategorie == null)
            {
                return NotFound();
            }

            return kategorie;
        }

        [HttpPost]
        public async Task<ActionResult<Kategorie>> CreateCategory(Kategorie kategorie)
        {
            _context.Kategorien.Add(kategorie);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetCategoryById), new { id = kategorie.Id }, kategorie);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCategory(int id, Kategorie kategorie)
        {
            if (id != kategorie.Id)
            {
                return BadRequest();
            }

            _context.Entry(kategorie).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_context.Kategorien.Any(e => e.Id == id))
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
        public async Task<IActionResult> DeleteCategory(int id)
        {
            var kategorie = await _context.Kategorien.FindAsync(id);
            if (kategorie == null)
            {
                return NotFound();
            }

            _context.Kategorien.Remove(kategorie);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
