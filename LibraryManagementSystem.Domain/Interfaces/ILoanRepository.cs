using LibraryManagementSystem.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace LibraryManagementSystem.Domain.Interfaces
{
    public interface ILoanRepository
    {
        Task<Loan?> GetLoanByIdAsync(int id);
        Task<IEnumerable<Loan>> GetActiveLoansByMemberIdAsync(string memberId);
        Task AddLoanAsync(Loan loan);
    }
}
