using System;
using System.Collections.Generic;
using System.Text;

namespace LibraryManagementSystem.Domain.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        public IBookRepository Books { get; }
        public ILoanRepository Loans { get; }
        Task<int> SaveChangesAsync();
    }
}
