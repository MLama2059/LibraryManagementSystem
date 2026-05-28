using LibraryManagementSystem.Domain.Entities;
using LibraryManagementSystem.Domain.Interfaces;
using LibraryManagementSystem.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace LibraryManagementSystem.Infrastructure.Repositories
{
    public class LoanRepository(ApplicationDbContext _context) : ILoanRepository
    {
        public async Task<Loan?> GetLoanByIdAsync(int id)
        {
            return await _context.Loans.FindAsync(id);
        }

        public async Task<IEnumerable<Loan>> GetActiveLoansByMemberIdAsync(string memberId)
        {
            return await _context.Loans.Where(l => l.MemberId == memberId && !l.IsReturned).ToListAsync();
        }

        public async Task AddLoanAsync(Loan loan)
        {
            await _context.Loans.AddAsync(loan);
        }
    }
}
