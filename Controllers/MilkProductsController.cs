using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace milkApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MilkProductsController : ControllerBase
    {
        private readonly MilkContext _context;

        public MilkProductsController(MilkContext context)
        {
            _context = context;
        }

        // GET: api/MilkProducts
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Milk>>> GetMilkProducts()
        {
            if (_context.MilkProducts == null)
            {
                return NotFound();
            }
            return await _context.MilkProducts.ToListAsync();
        }

        // GET: api/MilkProducts/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Milk>> GetMilk(string id)
        {
            if (_context.MilkProducts == null)
            {
                return NotFound();
            }
            var milk = await _context.MilkProducts.FindAsync(id);

            if (milk == null)
            {
                return NotFound();
            }

            return milk;
        }

        // PUT: api/MilkProducts/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMilk(string id, Milk milk)
        {
            if (id != milk.Id)
            {
                return BadRequest();
            }

            _context.Entry(milk).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MilkExists(id))
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

        [HttpPut("{id}/{quantity}")]
        public async Task<IActionResult> PutOrder( string id, int quantity)
        {
            var milkItem = await _context.MilkProducts.FirstOrDefaultAsync(p => p.Id == id);
            if (milkItem == null)
            {
                return BadRequest($"Milk with id {id} does not exist in Data Base");
            } 
            milkItem.Storage -= quantity;
            await _context.SaveChangesAsync();
            return Ok("Order is saved");
        }

        // POST: api/MilkProducts
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Milk>> PostMilk(Milk milk)
        {
            if (_context.MilkProducts == null)
            {
                return Problem("Entity set 'MilkContext.MilkProducts'  is null.");
            }
            _context.MilkProducts.Add(milk);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetMilk", new { id = milk.Id }, milk);
        }

        // DELETE: api/MilkProducts/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMilk(string id)
        {
            if (_context.MilkProducts == null)
            {
                return NotFound();
            }
            var milk = await _context.MilkProducts.FindAsync(id);
            if (milk == null)
            {
                return NotFound();
            }

            _context.MilkProducts.Remove(milk);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool MilkExists(string id)
        {
            return (_context.MilkProducts?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
