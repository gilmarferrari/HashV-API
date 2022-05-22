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
    [Route("api/budgets")]
    [ApiController]
    public class BudgetsController : ControllerBase
    {
        private readonly Database _context;

        public BudgetsController(Database context)
        {
            _context = context;
        }

        // GET: api/BudgetModels
        [HttpGet]
        public async Task<ActionResult<IEnumerable<BudgetModel>>> GetBudgets()
        {
            return await _context.Budgets.ToListAsync();
        }

        // GET: api/BudgetModels/5
        [HttpGet("{id}")]
        public async Task<ActionResult<BudgetModel>> GetBudgetModel(int id)
        {
            var budgetModel = await _context.Budgets.FindAsync(id);

            if (budgetModel == null)
            {
                return NotFound();
            }

            return budgetModel;
        }

        // PUT: api/BudgetModels/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBudgetModel(int id, BudgetModel budgetModel)
        {
            if (id != budgetModel.ID)
            {
                return BadRequest();
            }

            _context.Entry(budgetModel).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BudgetModelExists(id))
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

        // POST: api/BudgetModels
        [HttpPost]
        public async Task<ActionResult<BudgetModel>> PostBudgetModel(BudgetModel budgetModel)
        {
            _context.Budgets.Add(budgetModel);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetBudgetModel", new { id = budgetModel.ID }, budgetModel);
        }

        // DELETE: api/BudgetModels/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBudgetModel(int id)
        {
            var budgetModel = await _context.Budgets.FindAsync(id);
            if (budgetModel == null)
            {
                return NotFound();
            }

            _context.Budgets.Remove(budgetModel);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool BudgetModelExists(int id)
        {
            return _context.Budgets.Any(e => e.ID == id);
        }
    }
}
