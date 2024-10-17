using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TaskManager.Data.DataContext;
using TaskManager.Domain.Entities;

namespace TaskManager.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HistoryChangesController : ControllerBase
    {
        private readonly ApplicationContext _context;

        public HistoryChangesController(ApplicationContext context)
        {
            _context = context;
        }

        // GET: api/HistoryChanges
        [HttpGet]
        public async Task<ActionResult<IEnumerable<HistoryChange>>> GethistoryChanges()
        {
            return await _context.historyChanges.ToListAsync();
        }

        // GET: api/HistoryChanges/5
        [HttpGet("{id}")]
        public async Task<ActionResult<HistoryChange>> GetHistoryChange(int id)
        {
            var historyChange = await _context.historyChanges.FindAsync(id);

            if (historyChange == null)
            {
                return NotFound();
            }

            return historyChange;
        }

        // PUT: api/HistoryChanges/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutHistoryChange(int id, HistoryChange historyChange)
        {
            if (id != historyChange.Id)
            {
                return BadRequest();
            }

            _context.Entry(historyChange).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!HistoryChangeExists(id))
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

        // POST: api/HistoryChanges
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<HistoryChange>> PostHistoryChange(HistoryChange historyChange)
        {
            _context.historyChanges.Add(historyChange);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetHistoryChange", new { id = historyChange.Id }, historyChange);
        }

        // DELETE: api/HistoryChanges/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteHistoryChange(int id)
        {
            var historyChange = await _context.historyChanges.FindAsync(id);
            if (historyChange == null)
            {
                return NotFound();
            }

            _context.historyChanges.Remove(historyChange);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool HistoryChangeExists(int id)
        {
            return _context.historyChanges.Any(e => e.Id == id);
        }
    }
}
