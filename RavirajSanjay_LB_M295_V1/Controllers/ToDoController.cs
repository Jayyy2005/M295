using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RavirajSanjay_LB_M295_V1.Model;
using System;
using RavirajSanjay_LB_M295_V1.Data;

namespace RavirajSanjay_LB_M295_V1.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ToDoController : ControllerBase
    {
        private readonly AppDbContext _context;

        public ToDoController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ToDo>>> GetAllToDoItems()
        {
            return await _context.ToDos.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ToDo>> GetToDoItemById(int id)
        {
            var toDoItem = await _context.ToDos.FindAsync(id);

            if (toDoItem == null)
            {
                return NotFound();
            }

            return toDoItem;
        }

        [HttpPost]
        public async Task<ActionResult<ToDo>> CreateToDoItem(ToDo toDo)
        {
            _context.ToDos.Add(toDo);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetToDoItemById), new { id = toDo.Id }, toDo);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateToDoItem(int id, ToDo toDo)
        {
            if (id != toDo.Id)
            {
                return BadRequest();
            }

            _context.Entry(toDo).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ToDoItemExists(id))
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
        public async Task<IActionResult> DeleteToDoItem(int id)
        {
            var toDoItem = await _context.ToDos.FindAsync(id);
            if (toDoItem == null)
            {
                return NotFound();
            }

            _context.ToDos.Remove(toDoItem);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ToDoItemExists(int id)
        {
            return _context.ToDos.Any(e => e.Id == id);
        }
    }
}
