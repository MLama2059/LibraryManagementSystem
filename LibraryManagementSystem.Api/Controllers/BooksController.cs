using LibraryManagementSystem.Application.Books.Commands;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LibraryManagementSystem.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController(ISender _sender) : ControllerBase
    {
        [HttpPost]
        public async Task<IActionResult> CreateBook(CreateBookCommand command)
        {
            int bookId = await _sender.Send(command);

            return Ok(new {Id = bookId, Message = "Book created successfully." });
        }
    }
}
