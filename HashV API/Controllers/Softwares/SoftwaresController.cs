using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using HashV_API;
using HashV_API.Models;

namespace HashV_API.Controllers.Softwares
{
    [Route("api/softwares")]
    [ApiController]
    public class SoftwaresController : ControllerBase
    {
        private readonly Database _context;

        public SoftwaresController(Database context)
        {
            _context = context;
        }

        // GET: api/Softwares
        [HttpGet]
        public async Task<ActionResult<IEnumerable<SoftwareModel>>> GetSoftwares()
        {
            return await _context.Softwares.ToListAsync();
        }

        // GET: api/Softwares/5
        [HttpGet("{id}")]
        public async Task<ActionResult<SoftwareModel>> GetSoftwareModel(int id)
        {
            var softwareModel = await _context.Softwares.FindAsync(id);

            if (softwareModel == null)
            {
                return NotFound();
            }

            return softwareModel;
        }

        // PUT: api/Softwares/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSoftwareModel(int id, SoftwareModel softwareModel)
        {
            if (id != softwareModel.ID)
            {
                return BadRequest();
            }

            _context.Entry(softwareModel).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SoftwareModelExists(id))
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

        // POST: api/Softwares
        [HttpPost]
        public async Task<ActionResult<SoftwareModel>> PostSoftwareModel(SoftwareModel softwareModel)
        {
            _context.Softwares.Add(softwareModel);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetSoftwareModel", new { id = softwareModel.ID }, softwareModel);
        }

        // DELETE: api/Softwares/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSoftwareModel(int id)
        {
            var softwareModel = await _context.Softwares.FindAsync(id);
            if (softwareModel == null)
            {
                return NotFound();
            }

            _context.Softwares.Remove(softwareModel);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool SoftwareModelExists(int id)
        {
            return _context.Softwares.Any(e => e.ID == id);
        }
    }
}
