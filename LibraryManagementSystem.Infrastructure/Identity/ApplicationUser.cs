using LibraryManagementSystem.Domain.Entities;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace LibraryManagementSystem.Infrastructure.Identity
{
    public class ApplicationUser : IdentityUser
    {
        public string FullName { get; set; } = string.Empty;
        public decimal AccountBalance { get; set; } = 0.00m;
        public ICollection<Loan> Loans { get; set; } = new List<Loan>();
    }
}
