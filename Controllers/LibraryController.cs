using Library_Management.Services;
using Microsoft.AspNetCore.Mvc;

namespace Library_Management.Controllers
{
    [ApiController]
    [Route("api/library")]
    public class LibraryController : ControllerBase
    {
        private readonly ILibraryService _service;

        public LibraryController(ILibraryService service)
        {
            _service = service;
        }

        [HttpPost("borrow")]
        public async Task<IActionResult> Borrow(Guid memberId, Guid bookId)
        {
            var result = await _service.BorrowBook(memberId, bookId);
            return Ok(result);
        }

        [HttpPost("return")]
        public async Task<IActionResult> Return(Guid memberId, Guid bookId)
        {
            var result = await _service.ReturnBook(memberId, bookId);
            return Ok(result);
        }
    }
}
