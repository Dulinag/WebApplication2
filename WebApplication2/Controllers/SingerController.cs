using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ApiProject.Models;

namespace ApiProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SingerController : ControllerBase
    {
        private readonly MyFirstAPIDBContext _context;

        public SingerController(MyFirstAPIDBContext context)
        {
            _context = context;
        }

        // GET: api/Singer
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Singer>>> GetSinger()
        {
          
            return await _context.Singer.ToListAsync();
        }

        // GET: api/Singer/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Singer>> GetSinger(int id)
        {
          
            var singer = await _context.Singer.FindAsync(id);

            if (singer == null)
            {
                return NotFound();
            }

            return singer;
        }

        // PUT: api/Singer/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSinger(int id, Singer singer)
        {
            if (id != singer.SingerId)
            {
                return BadRequest();
            }

            _context.Entry(singer).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SingerExists(id))
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

        // POST: api/Singer
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Singer>> PostSinger(Singer singer)
        {
          if (_context.Singer == null)
          {
              return Problem("Entity set 'MyFirstAPIDBContext.Singer'  is null.");
          }
            _context.Singer.Add(singer);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetSinger", new { id = singer.SingerId }, singer);
        }

        // DELETE: api/Singer/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSinger(int id)
        {
            if (_context.Singer == null)
            {
                return NotFound();
            }
            var singer = await _context.Singer.FindAsync(id);
            if (singer == null)
            {
                return NotFound();
            }

            _context.Singer.Remove(singer);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool SingerExists(int id)
        {
            return (_context.Singer?.Any(e => e.SingerId == id)).GetValueOrDefault();
        }
    }
}
