using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using HashV_API.Models;
using HashV_API;

namespace HashV_API.Controllers.General
{
    [Route("api/versions")]
    [ApiController]
    public class VersionsController : ControllerBase
    {
        private readonly Database _context;

        public VersionsController(Database context)
        {
            _context = context;
        }

        // GET: api/VersionModels
        [HttpGet]
        public async Task<ActionResult<IEnumerable<VersionModel>>> GetVersions()
        {
            return await _context.Versions.ToListAsync();
        }

        // GET: api/VersionModels/5
        [HttpGet("{id}")]
        public async Task<ActionResult<VersionModel>> GetVersionModel(int id)
        {
            var versionModel = await _context.Versions.FindAsync(id);

            if (versionModel == null)
            {
                return NotFound();
            }

            return versionModel;
        }

        // PUT: api/VersionModels/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutVersionModel(int id, VersionModel versionModel)
        {
            if (id != versionModel.ID)
            {
                return BadRequest();
            }

            _context.Entry(versionModel).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!VersionModelExists(id))
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

        // POST: api/VersionModels
        [HttpPost]
        public async Task<ActionResult<VersionModel>> PostVersionModel(VersionModel versionModel)
        {
            _context.Versions.Add(versionModel);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetVersionModel", new { id = versionModel.ID }, versionModel);
        }

        // DELETE: api/VersionModels/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteVersionModel(int id)
        {
            var versionModel = await _context.Versions.FindAsync(id);
            if (versionModel == null)
            {
                return NotFound();
            }

            _context.Versions.Remove(versionModel);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool VersionModelExists(int id)
        {
            return _context.Versions.Any(e => e.ID == id);
        }
    }
}
