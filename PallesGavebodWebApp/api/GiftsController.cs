using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PallesGavebodWebApp.Models;

namespace PallesGavebodWebApp.api
{
	[Produces("application/json")]
	[Route("api/[controller]")]
    [ApiController]
    public class GiftsController : ControllerBase
    {
        private readonly MainDbContext _context;

        public GiftsController(MainDbContext context)
        {
            _context = context;
        }

		/// <summary>
		/// Returns all gifts from the database in JSON format
		/// </summary>
		/// <returns>Returns all gifts from the database in JSON format</returns>
		// GET: api/Gifts
		[HttpGet]
        public async Task<ActionResult<IEnumerable<Gift>>> GetGifts()
        {
            return await _context.Gifts.ToListAsync();
        }

        // GET: api/Gifts/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Gift>> GetGift(int id)
        {
            var gift = await _context.Gifts.FindAsync(id);

            if (gift == null)
            {
                return NotFound();
            }

            return gift;
        }

        // PUT: api/Gifts/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutGift(int id, Gift gift)
        {
            if (id != gift.GiftNumber)
            {
                return BadRequest();
            }

            _context.Entry(gift).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!GiftExists(id))
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

        // POST: api/Gifts
        [HttpPost]
        public async Task<ActionResult<Gift>> PostGift(Gift gift)
        {
			gift.CreationDate = DateTime.Now;

            _context.Gifts.Add(gift);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetGift", new { id = gift.GiftNumber }, gift);
        }

        // DELETE: api/Gifts/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Gift>> DeleteGift(int id)
        {
            var gift = await _context.Gifts.FindAsync(id);
            if (gift == null)
            {
                return NotFound();
            }

            _context.Gifts.Remove(gift);
            await _context.SaveChangesAsync();

            return gift;
        }

        private bool GiftExists(int id)
        {
            return _context.Gifts.Any(e => e.GiftNumber == id);
        }
    }
}
