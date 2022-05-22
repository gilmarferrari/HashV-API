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
    [Route("api/expenses")]
    [ApiController]
    public class ExpensesController : ControllerBase
    {
        private readonly Database _context;

        public ExpensesController(Database context)
        {
            _context = context;
        }

        // GET: api/ExpenseModels
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ExpenseModel>>> GetExpenses()
        {
            return await _context.Expenses.ToListAsync();
        }

        // GET: api/ExpenseModels/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ExpenseModel>> GetExpenseModel(int id)
        {
            var expenseModel = await _context.Expenses.FindAsync(id);

            if (expenseModel == null)
            {
                return NotFound();
            }

            return expenseModel;
        }

        // PUT: api/ExpenseModels/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutExpenseModel(int id, ExpenseModel expenseModel)
        {
            if (id != expenseModel.ID)
            {
                return BadRequest();
            }

            _context.Entry(expenseModel).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ExpenseModelExists(id))
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

        // POST: api/ExpenseModels
        [HttpPost]
        public async Task<ActionResult<ExpenseModel>> PostExpenseModel(ExpenseModel expenseModel)
        {
            _context.Expenses.Add(expenseModel);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetExpenseModel", new { id = expenseModel.ID }, expenseModel);
        }

        // DELETE: api/ExpenseModels/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteExpenseModel(int id)
        {
            var expenseModel = await _context.Expenses.FindAsync(id);
            if (expenseModel == null)
            {
                return NotFound();
            }

            _context.Expenses.Remove(expenseModel);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ExpenseModelExists(int id)
        {
            return _context.Expenses.Any(e => e.ID == id);
        }
    }
}
