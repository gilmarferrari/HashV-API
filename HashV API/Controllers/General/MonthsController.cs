using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using HashV_API.Models;
using HashV_API;

namespace HashV_API.Controllers
{
    [Route("api/months")]
    [ApiController]
    public class MonthsController : ControllerBase
    {
        private readonly Database _context;

        public MonthsController(Database context)
        {
            _context = context;
        }

        // GET: api/MonthModels
        [HttpGet]
        public async Task<ActionResult<IEnumerable<MonthModel>>> GetMonths()
        {
            return await _context.Months.ToListAsync();
        }

        // GET: api/MonthModels/5
        [HttpGet("{id}")]
        public async Task<ActionResult<MonthModel>> GetMonthModel(int id)
        {
            var monthModel = await _context.Months.FindAsync(id);

            if (monthModel == null)
            {
                return NotFound();
            }

            return monthModel;
        }

        // PUT: api/MonthModels/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMonthModel(int id, MonthModel monthModel)
        {
            if (id != monthModel.ID)
            {
                return BadRequest();
            }

            _context.Entry(monthModel).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MonthModelExists(id))
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

        // POST: api/MonthModels
        [HttpPost]
        public async Task<ActionResult<MonthModel>> PostMonthModel(MonthModel monthModel)
        {
            _context.Months.Add(monthModel);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetMonthModel", new { id = monthModel.ID }, monthModel);
        }

        // DELETE: api/MonthModels/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMonthModel(int id)
        {
            var monthModel = await _context.Months.FindAsync(id);
            if (monthModel == null)
            {
                return NotFound();
            }

            _context.Months.Remove(monthModel);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool MonthModelExists(int id)
        {
            return _context.Months.Any(e => e.ID == id);
        }
    }
}
