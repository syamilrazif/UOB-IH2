using Library_Management.Data;
using Library_Management.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Library_Management.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MembersController : ControllerBase
    {
        private readonly LibraryDbContext _context;

        public MembersController(LibraryDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _context.Members.ToListAsync());
        }

        [HttpPost]
        public async Task<IActionResult> Create(Member member)
        {
            _context.Members.Add(member);
            await _context.SaveChangesAsync();

            return Ok(member);
        }
    }
}