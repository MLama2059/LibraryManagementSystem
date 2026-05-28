using LibraryManagementSystem.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace LibraryManagementSystem.Application.Books.Commands
{
    public record CreateBookCommand(string Title, string Author, string ISBN, string Genre, int TotalCopies) : IRequest<int>;
}
