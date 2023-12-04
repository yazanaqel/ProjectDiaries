using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProjectDiaries.Server.Data;
using ProjectDiaries.Shared;

namespace ProjectDiaries.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DiariesController : ControllerBase
    {
        private readonly DataContext _context;

        public DiariesController(DataContext context)
        {
            _context = context;
        }

        // GET: api/Diaries
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Diary>>> GetDiaries()
        {
          if (_context.Diaries == null)
          {
              return NotFound();
          }
            return await _context.Diaries.OrderByDescending(x => x.DateCreated).ToListAsync();
        }

        // GET: api/Diaries/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Diary>> GetDiary(int id)
        {
          if (_context.Diaries == null)
          {
              return NotFound();
          }
            var diary = await _context.Diaries.FindAsync(id);

            if (diary == null)
            {
                return NotFound();
            }

            return Ok(diary);
        }

        // PUT: api/Diaries/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDiary(int id, Diary diary)
        {
            if (id != diary.Id)
            {
                return BadRequest();
            }

            _context.Entry(diary).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DiaryExists(id))
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

        // POST: api/Diaries
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Diary>> PostDiary(Diary diary)
        {
          if (_context.Diaries == null)
          {
              return Problem("Entity set 'DataContext.Diaries'  is null.");
          }
            _context.Diaries.Add(diary);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetDiary", new { id = diary.Id }, diary);
        }

        // DELETE: api/Diaries/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDiary(int id)
        {
            if (_context.Diaries == null)
            {
                return NotFound();
            }
            var diary = await _context.Diaries.FindAsync(id);
            if (diary == null)
            {
                return NotFound();
            }

            _context.Diaries.Remove(diary);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool DiaryExists(int id)
        {
            return (_context.Diaries?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
