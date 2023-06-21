using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RestouracjaAPI.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace YourNamespace.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PizzaMenuController : ControllerBase
    {
        private readonly RestourantdbContext _context;

        public PizzaMenuController(RestourantdbContext context)
        {
            _context = context;
        }

        // GET: api/PizzaMenu
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PizzaMenu>>> GetPizzaMenu()
        {
            return await _context.PizzaMenus.ToListAsync();
        }

        // GET: api/PizzaMenu/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PizzaMenu>> GetPizzaMenu(int id)
        {
            var pizzaMenu = await _context.PizzaMenus.FindAsync(id);

            if (pizzaMenu == null)
            {
                return NotFound();
            }

            return pizzaMenu;
        }

        // POST: api/PizzaMenu
        [HttpPost]
        public async Task<ActionResult<PizzaMenu>> PostPizzaMenu(PizzaMenu pizzaMenu)
        {
            _context.PizzaMenus.Add(pizzaMenu);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPizzaMenu", new { id = pizzaMenu.Id }, pizzaMenu);
        }

        // PUT: api/PizzaMenu/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPizzaMenu(int id, PizzaMenu pizzaMenu)
        {
            if (id != pizzaMenu.Id)
            {
                return BadRequest();
            }

            _context.Entry(pizzaMenu).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PizzaMenuExists(id))
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

        // DELETE: api/PizzaMenu/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePizzaMenu(int id)
        {
            var pizzaMenu = await _context.PizzaMenus.FindAsync(id);
            if (pizzaMenu == null)
            {
                return NotFound();
            }

            _context.PizzaMenus.Remove(pizzaMenu);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool PizzaMenuExists(int id)
        {
            return _context.PizzaMenus.Any(e => e.Id == id);
        }
    }
}