using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using HashV_API.Models;
using HashV_API;

namespace HashV_API.Controllers.Passwords
{
    [Route("api/passwords")]
    [ApiController]
    public class PasswordsController : ControllerBase
    {
        private readonly Database _context;

        public PasswordsController(Database context)
        {
            _context = context;
        }

        // GET: api/Passwords
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PasswordModel>>> GetPasswords()
        {
            return await _context.Passwords.ToListAsync();
        }

        // GET: api/Passwords/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PasswordModel>> GetPasswordModel(int id)
        {
            var passwordModel = await _context.Passwords.FindAsync(id);

            if (passwordModel == null)
            {
                return NotFound();
            }

            return passwordModel;
        }

        // PUT: api/Passwords/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPasswordModel(int id, PasswordModel passwordModel)
        {
            if (id != passwordModel.ID)
            {
                return BadRequest();
            }

            _context.Entry(passwordModel).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PasswordModelExists(id))
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

        // POST: api/Passwords
        [HttpPost]
        public async Task<ActionResult<PasswordModel>> PostPasswordModel(PasswordModel passwordModel)
        {
            _context.Passwords.Add(passwordModel);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPasswordModel", new { id = passwordModel.ID }, passwordModel);
        }

        // DELETE: api/Passwords/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePasswordModel(int id)
        {
            var passwordModel = await _context.Passwords.FindAsync(id);
            if (passwordModel == null)
            {
                return NotFound();
            }

            _context.Passwords.Remove(passwordModel);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool PasswordModelExists(int id)
        {
            return _context.Passwords.Any(e => e.ID == id);
        }
    }
}
