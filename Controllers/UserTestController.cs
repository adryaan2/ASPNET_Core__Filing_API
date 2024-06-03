using Filing_API.Data;
using Filing_API.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Filing_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserTestController : ControllerBase
    {
        private readonly FilingDbContext _context;

        public UserTestController(FilingDbContext context)
        {
            _context = context;
        }

        [HttpGet("all")]
        public async Task<ActionResult<IEnumerable<UserT>>> GetUsers() { return await _context.UserTs.ToListAsync(); }

        [HttpGet("byId/{id}")]
        public async Task<ActionResult<UserT>> GetUserById(Guid id)
        {
            var user = await _context.UserTs.FindAsync(id);
            if (user == null)
                return NotFound();

            return Ok(user);
        }
    }
}
