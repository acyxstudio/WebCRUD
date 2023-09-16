using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SQLitePCL;
using System.Linq.Expressions;
using WebCRUD.Data;

namespace WebCRUD.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonController : ControllerBase
    {
        private readonly DataContext _context;
        public PersonController(DataContext context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task<ActionResult<List<Person>>> AddPerson(Person person)
        {
            _context.PersonsTable.Add(person);

            await _context.SaveChangesAsync();
            
            return Ok(await _context.PersonsTable.ToListAsync());
        }
        
        [HttpGet]
        public async Task<ActionResult<List<Person>>> GetAllPersons()
        {
            return Ok(await _context.PersonsTable.ToListAsync());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<List<Person>>> GetPerson(int id)
        {
            var _personFound = await _context.PersonsTable.FindAsync(id);

            if (_personFound == null)
            {
                return BadRequest("Person not found!");
            }
            return Ok(_personFound);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<List<Person>>> UpdatePerson(int id, Person person)
        {
            if (id != person.Id)
            {
                return BadRequest("Id and Person does not match!");
            }
            
            
            _context.Entry(person).State = EntityState.Modified;

            try
            {
              await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {    
               return NotFound();
            }

            return NoContent();
            
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<List<Person>>> DeletePerson(int id)
        {
            Person _personFound = await _context.PersonsTable.FindAsync(id);
            
            if (_personFound == null)
            {
                return BadRequest("Person not found to be deleted!");
            }

            _context.PersonsTable.Remove(_personFound);

            await _context.SaveChangesAsync();

            return Ok(new { message = "User deleted" });
        }
    }
}
