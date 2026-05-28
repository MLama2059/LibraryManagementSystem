using LibraryManagementSystem.Application.DTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace LibraryManagementSystem.Application.Books.Queries
{
    public record GetBookByIdQuery(int id) : IRequest<ReadBookDto?>;
}
