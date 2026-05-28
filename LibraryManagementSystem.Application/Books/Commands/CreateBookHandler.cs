using LibraryManagementSystem.Domain.Entities;
using LibraryManagementSystem.Domain.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace LibraryManagementSystem.Application.Books.Commands
{
    public class CreateBookHandler(IUnitOfWork _unitOfWork) : IRequestHandler<CreateBookCommand, int>
    {
        public async Task<int> Handle(CreateBookCommand request, CancellationToken cancellationToken)
        {
            var book = new Book
            {
                Title = request.Title,
                Author = request.Author,
                ISBN = request.ISBN,
                Genre = request.Genre,
                TotalCopies = request.TotalCopies,
                AvailableCopies = request.TotalCopies
            };

            await _unitOfWork.Books.AddBookAsync(book);
            await _unitOfWork.SaveChangesAsync();

            return book.Id;
        }
    }
}
