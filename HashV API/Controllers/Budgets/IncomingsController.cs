using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using HashV_API;
using HashV_API.Models;

namespace HashV_API.Controllers.Budgets
{
    [Route("api/incomings")]
    [ApiController]
    public class IncomingsController : ControllerBase
    {
        private readonly Database _context;

        public IncomingsController(Database context)
        {
            _context = context;
        }

        // GET: api/Incomings
        [HttpGet]
        public async Task<ActionResult<IEnumerable<IncomingModel>>> GetIncomings()
        {
            return await _context.Incomings.ToListAsync();
        }

        // GET: api/Incomings/5
        [HttpGet("{id}")]
        public async Task<ActionResult<IncomingModel>> GetIncomingModel(int id)
        {
            var incomingModel = await _context.Incomings.FindAsync(id);

            if (incomingModel == null)
            {
                return NotFound();
            }

            return incomingModel;
        }

        // PUT: api/Incomings/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutIncomingModel(int id, IncomingModel incomingModel)
        {
            if (id != incomingModel.ID)
            {
                return BadRequest();
            }

            _context.Entry(incomingModel).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!IncomingModelExists(id))
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

        // POST: api/Incomings
        [HttpPost]
        public async Task<ActionResult<IncomingModel>> PostIncomingModel(IncomingModel incomingModel)
        {
            _context.Incomings.Add(incomingModel);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetIncomingModel", new { id = incomingModel.ID }, incomingModel);
        }

        // DELETE: api/Incomings/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteIncomingModel(int id)
        {
            var incomingModel = await _context.Incomings.FindAsync(id);
            if (incomingModel == null)
            {
                return NotFound();
            }

            _context.Incomings.Remove(incomingModel);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool IncomingModelExists(int id)
        {
            return _context.Incomings.Any(e => e.ID == id);
        }
    }
}
