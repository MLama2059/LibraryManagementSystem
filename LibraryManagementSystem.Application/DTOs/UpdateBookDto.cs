using System;
using System.Collections.Generic;
using System.Text;

namespace LibraryManagementSystem.Application.DTOs
{
    public record UpdateBookDto(string Title, string Author, string ISBN, string Genre, int TotalCopies);
}
