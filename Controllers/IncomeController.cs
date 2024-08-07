using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PersonalFinanceManagementAPI.Data;
using PersonalFinanceManagementAPI.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PersonalFinanceManagementAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IncomeController : ControllerBase
    {
        private readonly AppDbContext _context;

        public IncomeController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Income>>> GetIncomes()
        {
            return await _context.Incomes.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Income>> GetIncome(int id)
        {
            var income = await _context.Incomes.FindAsync(id);

            if (income == null)
            {
                return NotFound();
            }

            return income;
        }

        [HttpPost]
        public async Task<ActionResult<Income>> PostIncome(Income income)
        {
            _context.Incomes.Add(income);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetIncome", new { id = income.IncomeId }, income);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutIncome(int id, Income income)
        {
            if (id != income.IncomeId)
            {
                return BadRequest();
            }

            _context.Entry(income).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!IncomeExists(id))
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

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteIncome(int id)
        {
            var income = await _context.Incomes.FindAsync(id);
            if (income == null)
            {
                return NotFound();
            }

            _context.Incomes.Remove(income);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool IncomeExists(int id)
        {
            return _context.Incomes.Any(e => e.IncomeId == id);
        }
    }
}
