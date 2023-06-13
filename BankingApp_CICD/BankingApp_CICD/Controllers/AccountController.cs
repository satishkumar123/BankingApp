using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BankingApp_CICD.EF.Models;

namespace BankingApp_CICD.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase   // Test 1
    {
        private readonly SatishApiDbContext _context = new SatishApiDbContext();

        public AccountController(SatishApiDbContext context)
        {
            _context = context;
        }

        // GET: api/Account
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AccountDetailsNew>>> GetAccountDetailsNews()
        {
          if (_context.AccountDetailsNews == null)
          {
              return NotFound();
          }
            return await _context.AccountDetailsNews.ToListAsync();
        }

        // GET: api/Account/5
        [HttpGet("{id}")]
        public async Task<ActionResult<AccountDetailsNew>> GetAccountDetailsNew(int id)
        {
          if (_context.AccountDetailsNews == null)
          {
              return NotFound();
          }
            var accountDetailsNew = await _context.AccountDetailsNews.FindAsync(id);

            if (accountDetailsNew == null)
            {
                return NotFound();
            }

            return accountDetailsNew;
        }

        // PUT: api/Account/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAccountDetailsNew(int id, AccountDetailsNew accountDetailsNew)
        {
            if (id != accountDetailsNew.AccId)
            {
                return BadRequest();
            }

            _context.Entry(accountDetailsNew).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AccountDetailsNewExists(id))
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

        // POST: api/Account
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<AccountDetailsNew>> PostAccountDetailsNew(AccountDetailsNew accountDetailsNew)
        {
          if (_context.AccountDetailsNews == null)
          {
              return Problem("Entity set 'SatishApiDbContext.AccountDetailsNews'  is null.");
          }
            _context.AccountDetailsNews.Add(accountDetailsNew);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAccountDetailsNew", new { id = accountDetailsNew.AccId }, accountDetailsNew);
        }

        // DELETE: api/Account/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAccountDetailsNew(int id)
        {
            if (_context.AccountDetailsNews == null)
            {
                return NotFound();
            }
            var accountDetailsNew = await _context.AccountDetailsNews.FindAsync(id);
            if (accountDetailsNew == null)
            {
                return NotFound();
            }

            _context.AccountDetailsNews.Remove(accountDetailsNew);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool AccountDetailsNewExists(int id)
        {
            return (_context.AccountDetailsNews?.Any(e => e.AccId == id)).GetValueOrDefault();
        }
    }
}
