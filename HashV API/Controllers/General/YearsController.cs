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
    [Route("api/years")]
    [ApiController]
    public class YearsController : ControllerBase
    {
        private readonly Database _context;

        public YearsController(Database context)
        {
            _context = context;
        }

        // GET: api/YearModels
        [HttpGet]
        public async Task<ActionResult<IEnumerable<YearModel>>> GetYears()
        {
            return await _context.Years.ToListAsync();
        }

        // GET: api/YearModels/5
        [HttpGet("{id}")]
        public async Task<ActionResult<YearModel>> GetYearModel(int id)
        {
            var yearModel = await _context.Years.FindAsync(id);

            if (yearModel == null)
            {
                return NotFound();
            }

            return yearModel;
        }

        // PUT: api/YearModels/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutYearModel(int id, YearModel yearModel)
        {
            if (id != yearModel.ID)
            {
                return BadRequest();
            }

            _context.Entry(yearModel).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!YearModelExists(id))
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

        // POST: api/YearModels
        [HttpPost]
        public async Task<ActionResult<YearModel>> PostYearModel(YearModel yearModel)
        {
            _context.Years.Add(yearModel);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetYearModel", new { id = yearModel.ID }, yearModel);
        }

        // DELETE: api/YearModels/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteYearModel(int id)
        {
            var yearModel = await _context.Years.FindAsync(id);
            if (yearModel == null)
            {
                return NotFound();
            }

            _context.Years.Remove(yearModel);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool YearModelExists(int id)
        {
            return _context.Years.Any(e => e.ID == id);
        }
    }
}
