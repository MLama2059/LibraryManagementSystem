using LibraryManagementSystem.Application.DTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace LibraryManagementSystem.Application.Loans.Commands
{
    public record BorrowBookCommand(BorrowBookDto dto) : IRequest<bool>;
}
