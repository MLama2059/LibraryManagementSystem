using LibraryManagementSystem.Application.DTOs;
using LibraryManagementSystem.Domain.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace LibraryManagementSystem.Application.Books.Queries
{
    public class GetBookByIdHandler(IUnitOfWork _unitOfWork) : IRequestHandler<GetBookByIdQuery, ReadBookDto?>
    {
        public async Task<ReadBookDto?> Handle(GetBookByIdQuery request, CancellationToken cancellationToken)
        {
            var book = await _unitOfWork.Books.GetBookByIdAsync(request.id);

            if (book == null)
            {
                return null;
            }

            return new ReadBookDto
            (
                book.Id,
                book.Title,
                book.Author,
                book.ISBN,
                book.Genre,
                book.AvailableCopies
            );
        }
    }
}
