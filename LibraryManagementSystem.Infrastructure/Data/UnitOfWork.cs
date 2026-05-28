using LibraryManagementSystem.Domain.Interfaces;
using LibraryManagementSystem.Infrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace LibraryManagementSystem.Infrastructure.Data
{
    public class UnitOfWork(ApplicationDbContext _context) : IUnitOfWork
    {
        private IBookRepository? _books;
        private ILoanRepository? _loans;

        public IBookRepository Books => _books ??= new BookRepository(_context);

        public ILoanRepository Loans => _loans ??= new LoanRepository(_context);

        public async Task<int> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
