using FluentValidation;
using LibraryManagementSystem.Application.Books.Commands;
using LibraryManagementSystem.Application.Books.Queries;
using LibraryManagementSystem.Application.DTOs;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LibraryManagementSystem.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController(ISender _sender) : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetAllBooks()
        {
            var books = await _sender.Send(new GetAllBooksQuery());
            return Ok(books);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetBookById(int id)
        {
            var book = await _sender.Send(new GetBookByIdQuery(id));

            if (book == null)
            {
                return NotFound(new { Message = $"Book with Id {id} not found" });
            }

            return Ok(book);
        }

        [HttpPost]
        public async Task<IActionResult> CreateBook(CreateBookDto dto, [FromServices] IValidator<CreateBookCommand> _validator)
        {
            var command = new CreateBookCommand(dto);

            var validationResult = await _validator.ValidateAsync(command);
            if (!validationResult.IsValid)
            {
                return BadRequest(validationResult.ToDictionary());
            }

            int bookId = await _sender.Send(command);

            return CreatedAtAction(nameof(GetBookById), new { id = bookId }, new { Id = bookId, Message = "Book created successfully." });
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateBook(int id, UpdateBookDto dto, [FromServices] IValidator<UpdateBookCommand> _validator)
        {
            var command = new UpdateBookCommand(id, dto);

            var validationResult = await _validator.ValidateAsync(command);
            if (!validationResult.IsValid)
            {
                return BadRequest(validationResult.ToDictionary());
            }

            var result = await _sender.Send(command );

            if (!result)
            {
                return NotFound(new { Message = $"Cannot update. Book with Id {id} was not found." });
            }

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBook(int id)
        {
            var result = await _sender.Send(new DeleteBookCommand(id));

            if (!result)
            {
                return NotFound(new { Message = $"Cannot delete. Book with Id {id} was not found." });
            }

            return NoContent();
        }
    }
}
