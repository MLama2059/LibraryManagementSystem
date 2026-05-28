using LibraryManagementSystem.Application.DTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace LibraryManagementSystem.Application.Books.Commands
{
    public record UpdateBookCommand(int id, UpdateBookDto dto) : IRequest<bool>;
}
