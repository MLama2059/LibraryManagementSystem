using System;
using System.Collections.Generic;
using System.Text;

namespace LibraryManagementSystem.Application.DTOs
{
    public record CreateBookDto(string Title, string Author, string ISBN, string Genre, int TotalCopies);
}
