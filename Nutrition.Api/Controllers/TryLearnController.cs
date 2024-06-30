using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Nutrition.Api.Models;

namespace Nutrition.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TryLearnController : ControllerBase
    {
        private readonly TryLearnContext _context;

        public TryLearnController(TryLearnContext context)
        {
            _context = context;
        }

        // GET: api/TryLearn
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TryLearn>>> GetTryLearns()
        {
            return await _context.TryLearns.ToListAsync();
        }

        // GET: api/TryLearn/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TryLearn>> GetTryLearn(long id)
        {
            var tryLearn = await _context.TryLearns.FindAsync(id);

            if (tryLearn == null)
            {
                return NotFound();
            }

            return tryLearn;
        }

        // PUT: api/TryLearn/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTryLearn(long id, TryLearn tryLearn)
        {
            if (id != tryLearn.Id)
            {
                return BadRequest();
            }

            _context.Entry(tryLearn).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TryLearnExists(id))
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

        // POST: api/TryLearn
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<TryLearn>> PostTryLearn(TryLearn tryLearn)
        {
            _context.TryLearns.Add(tryLearn);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTryLearn", new { id = tryLearn.Id }, tryLearn);
        }

        // DELETE: api/TryLearn/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTryLearn(long id)
        {
            var tryLearn = await _context.TryLearns.FindAsync(id);
            if (tryLearn == null)
            {
                return NotFound();
            }

            _context.TryLearns.Remove(tryLearn);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TryLearnExists(long id)
        {
            return _context.TryLearns.Any(e => e.Id == id);
        }
    }
}
