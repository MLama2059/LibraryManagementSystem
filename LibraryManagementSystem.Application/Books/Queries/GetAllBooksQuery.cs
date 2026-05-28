using LibraryManagementSystem.Application.DTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace LibraryManagementSystem.Application.Books.Queries
{
    public record GetAllBooksQuery : IRequest<IEnumerable<ReadBookDto>>;
}
