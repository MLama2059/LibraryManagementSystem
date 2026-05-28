using System;
using System.Collections.Generic;
using System.Text;

namespace LibraryManagementSystem.Application.DTOs
{
    public record ReadBookDto(int Id, string Title, string Author, string ISBN, string Genre, int AvailableCopies);
}
