using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PersonalFinanceManagementAPI.Data;
using PersonalFinanceManagementAPI.Models;
using System.Reflection.Metadata;

namespace PersonalFinanceManagementAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InvestmentController(AppDbContext context) : ControllerBase
    {
        private readonly AppDbContext _context = context;

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Investment>>> GetInvestments()
        {
            return await _context.Investments.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Investment>> GetInvestment(int id)
        {
            var investment = await _context.Investments.FindAsync(id);

            if (investment == null)
            {
                return NotFound();
            }

            return investment;
        }

        [HttpPost]
        public async Task<ActionResult<Investment>> PostInvestment(Investment investment)
        {
            _context.Investments.Add(investment);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetInvestment", new { id = investment.InvestmentId }, investment);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutInvestment(int id, Investment investment)
        {
            if (id != investment.InvestmentId)
            {
                return BadRequest();
            }

            _context.Entry(investment).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!InvestmentExists(id))
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
        public async Task<IActionResult> DeleteInvestment(int id)
        {
            var investment = await _context.Investments.FindAsync(id);
            if (investment == null)
            {
                return NotFound();
            }

            _context.Investments.Remove(investment);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool InvestmentExists(int id)
        {
            return _context.Investments.Any(e => e.InvestmentId == id);
        }
    }
}
