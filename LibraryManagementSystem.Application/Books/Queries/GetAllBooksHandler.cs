using LibraryManagementSystem.Application.DTOs;
using LibraryManagementSystem.Domain.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace LibraryManagementSystem.Application.Books.Queries
{
    public class GetAllBooksHandler(IUnitOfWork _unitOfWork) : IRequestHandler<GetAllBooksQuery, IEnumerable<ReadBookDto>>
    {
        public async Task<IEnumerable<ReadBookDto>> Handle(GetAllBooksQuery request, CancellationToken cancellationToken)
        {
            var books = await _unitOfWork.Books.GetAllBooksAsync();

            return books.Select(book => new ReadBookDto
            (
                book.Id,
                book.Title,
                book.Author,
                book.ISBN,
                book.Genre,
                book.AvailableCopies
            ));
        }
    }
}
