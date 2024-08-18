using Filing_API.Data;
using Filing_API.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Filing_API.Controllers
{
    [Route("api/contact")]
    [ApiController]
    public class ContactController : ControllerBase
    {
        private readonly FilingDbContext _context;
        public ContactController(FilingDbContext context)
        {
            _context = context;
        }

        // GET: api/<ContactController>
        [HttpGet]
        public IEnumerable<ContactT> GetAll()
        {
            return _context.ContactTs;
        }

        // GET api/<ContactController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            ContactT? res = _context.ContactTs.First(ct => ct.Id.Equals(id));

            return res==null?NotFound() : Ok(res);
        }

        // POST api/<ContactController>
        [HttpPost]
        public IActionResult Post([FromBody] ContactT newContact)
        {
            _context.ContactTs.Add(newContact);
            _context.SaveChanges();

            return Created();
        }

        // PUT api/<ContactController>/5
        [HttpPut("{id}")]
        public IActionResult Put(Guid id, [FromBody] ContactT updateContact)
        {
            if (_context.ContactTs.Find(id) == null)
                return BadRequest();
            _context.ContactTs.Update(updateContact);
            _context.SaveChanges();

            return Ok();
        }

        // DELETE api/<ContactController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
