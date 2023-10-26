using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ContactsAPI.Models;
using Microsoft.AspNetCore.Authorization;

namespace ContactsAPI.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class ContactSkillLevelsController : ControllerBase
    {
        private readonly ContactsContext _context;

        public ContactSkillLevelsController(ContactsContext context)
        {
            _context = context;
            context.Database.EnsureCreated();
        }

        // GET: api/ContactSkillLevels
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ContactSkillLevel>>> GetContactSkillLevel()
        {
          if (_context.ContactSkillLevels == null)
          {
              return NotFound();
          }
            return await _context.ContactSkillLevels.ToListAsync();
        }

        // GET: api/ContactSkillLevels/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ContactSkillLevel>> GetContactSkillLevel(int id)
        {
          if (_context.ContactSkillLevels == null)
          {
              return NotFound();
          }
            var contactSkillLevel = await _context.ContactSkillLevels.FindAsync(id);

            if (contactSkillLevel == null)
            {
                return NotFound();
            }

            return contactSkillLevel;
        }

        // PUT: api/ContactSkillLevels/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutContactSkillLevel(int id, ContactSkillLevel contactSkillLevel)
        {
            if (id != contactSkillLevel.Id)
            {
                return BadRequest();
            }

            _context.Entry(contactSkillLevel).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ContactSkillLevelExists(id))
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

        // POST: api/ContactSkillLevels
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ContactSkillLevel>> PostContactSkillLevel(ContactSkillLevel contactSkillLevel)
        {
          if (_context.ContactSkillLevels == null)
          {
              return Problem("Entity set 'ContactsContext.ContactSkillLevel'  is null.");
          }
            _context.ContactSkillLevels.Add(contactSkillLevel);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetContactSkillLevel", new { id = contactSkillLevel.Id }, contactSkillLevel);
        }

        // DELETE: api/ContactSkillLevels/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteContactSkillLevel(int id)
        {
            if (_context.ContactSkillLevels == null)
            {
                return NotFound();
            }
            var contactSkillLevel = await _context.ContactSkillLevels.FindAsync(id);
            if (contactSkillLevel == null)
            {
                return NotFound();
            }

            _context.ContactSkillLevels.Remove(contactSkillLevel);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ContactSkillLevelExists(int id)
        {
            return (_context.ContactSkillLevels?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
