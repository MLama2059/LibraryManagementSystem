using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace LibraryManagementSystem.Application.Books.Commands
{
    public record DeleteBookCommand(int id) : IRequest<bool>;
}
