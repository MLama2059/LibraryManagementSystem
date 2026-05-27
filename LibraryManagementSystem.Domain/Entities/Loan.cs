using System;
using System.Collections.Generic;
using System.Text;

namespace LibraryManagementSystem.Domain.Entities
{
    public class Loan
    {
        public int Id { get; set; }
        public int BookId { get; set; }
        public string MemberId { get; set; } = string.Empty;
        public DateTime BorrowDate { get; set; }
        public DateTime DueDate { get; set; }
        public DateTime? ReturnDate { get; set; }
        public bool IsReturned { get; set; }
        public Book Book { get; set; } = null!;
    }
}
