using System;
using System.Collections.Generic;
using System.Text;

namespace LibraryManagementSystem.Application.DTOs
{
    public record BorrowBookDto(int BookId, string MemberId, int LoanDays = 14);
}
