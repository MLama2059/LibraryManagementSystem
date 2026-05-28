using LibraryManagementSystem.Domain.Entities;
using LibraryManagementSystem.Domain.Interfaces;
using LibraryManagementSystem.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace LibraryManagementSystem.Infrastructure.Repositories
{
    public class BookRepository(ApplicationDbContext _context) : IBookRepository
    {
        public async Task<IEnumerable<Book>> GetAllBooksAsync()
        {
            return await _context.Books.ToListAsync();
        }

        public async Task<Book?> GetBookByIdAsync(int id)
        {
            return await _context.Books.FindAsync(id);
        }

        public async Task AddBookAsync(Book book)
        {
            await _context.Books.AddAsync(book);
        }

        public void UpdateBook(Book book)
        {
            _context.Books.Update(book);
        }

        public void DeleteBook(Book book)
        {
            _context.Books.Remove(book);
        }
    }
}
