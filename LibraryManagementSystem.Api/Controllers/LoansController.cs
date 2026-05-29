using FluentValidation;
using LibraryManagementSystem.Application.DTOs;
using LibraryManagementSystem.Application.Loans.Commands;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LibraryManagementSystem.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoansController(ISender _sender) : ControllerBase
    {
        [HttpPost]
        public async Task<IActionResult> BorrowBook(BorrowBookDto dto, [FromServices] IValidator<BorrowBookCommand> _validator)
        {
            var command = new BorrowBookCommand(dto);

            var validationResult = await _validator.ValidateAsync(command);
            if (!validationResult.IsValid)
            {
                return BadRequest(validationResult.ToDictionary());
            }

            bool result = await _sender.Send(command);

            if (!result)
            {
                return BadRequest(new { Message = "The requested book is either not found or has no available copies remaining." });
            }

            return Ok(new { Message = "Book checked out successfully!" });
        }
    }
}
