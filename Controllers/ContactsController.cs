﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TestbART.Data;
using TestbART.Model;

namespace TestbART.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactsController : ControllerBase
    {
        private readonly TestbARTContext _context;

        public ContactsController(TestbARTContext context)
        {
            _context = context;
        }

        // GET: api/Contacts
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Contact>>> GetContacts()
        {
          if (_context.Contacts == null)
          {
              return NotFound();
          }
            return await _context.Contacts.ToListAsync();
        }

        // GET: api/Contacts/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Contact>> GetContacts(string id)
        {
          if (_context.Contacts == null)
          {
              return NotFound();
          }
            var contacts = await _context.Contacts.FindAsync(id);

            if (contacts == null)
            {
                return NotFound();
            }

            return contacts;
        }

        // PUT: api/Contacts/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutContacts(string id, Contact contacts)
        {
            if (id != contacts.Email)
            {
                return BadRequest();
            }

            _context.Entry(contacts).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ContactsExists(id))
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

        // POST: api/Contacts
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Contact>> PostContacts(Contact contacts)
        {
          if (_context.Contacts == null)
          {
              return Problem("Entity set 'TestbARTContext.Contacts'  is null.");
          }
            _context.Contacts.Add(contacts);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (ContactsExists(contacts.Email))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetContacts", new { id = contacts.Email }, contacts);
        }

        // DELETE: api/Contacts/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteContacts(string id)
        {
            if (_context.Contacts == null)
            {
                return NotFound();
            }
            var contacts = await _context.Contacts.FindAsync(id);
            if (contacts == null)
            {
                return NotFound();
            }

            _context.Contacts.Remove(contacts);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ContactsExists(string id)
        {
            return (_context.Contacts?.Any(e => e.Email == id)).GetValueOrDefault();
        }
    }
}
