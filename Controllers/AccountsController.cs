using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TestbART.Data;
using TestbART.Model;
using TestbART.Services;

namespace TestbART.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountsController : ControllerBase
    {
        private readonly TestbARTContext _context;
        private readonly AccountService _accountService;

        public AccountsController(TestbARTContext context, AccountService accountService)
        {
            _context = context;
            _accountService = accountService;
        }

        // GET: api/Accounts
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Account>>> GetAccounts()
        {
            return Ok(_accountService.GetAllAccounts());
        }

        // GET: api/Accounts/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Account>> GetAccounts(int id)
        {
          if (_context.Accounts == null)
          {
              return NotFound();
          }
            var accounts = await _context.Accounts.FindAsync(id);

            if (accounts == null)
            {
                return NotFound();
            }

            return accounts;
        }

        // PUT: api/Accounts/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAccounts(int id, Account accounts)
        {
            await _accountService.UpdateAccountAsync(id, accounts);

            return Ok();
        }

        // POST: api/Accounts
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Account>> PostAccounts(Account accounts)
        {
            await _accountService.CreateAccountAsync(accounts);

            return CreatedAtAction("GetAccounts", new { id = accounts.Id }, accounts);
        }

        // DELETE: api/Accounts/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAccounts(int id)
        {
            if (_context.Accounts == null)
            {
                return NotFound();
            }
            var accounts = await _context.Accounts.FindAsync(id);
            if (accounts == null)
            {
                return NotFound();
            }

            _context.Accounts.Remove(accounts);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool AccountsExists(int id)
        {
            return (_context.Accounts?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
