using LibraryManagementSystem.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace LibraryManagementSystem.Domain.Interfaces
{
    public interface IBookRepository
    {
        Task<IEnumerable<Book>> GetAllBooksAsync();
        Task<Book?> GetBookByIdAsync(int id);
        Task AddBookAsync(Book book);
        void UpdateBook(Book book);
        void DeleteBook(Book book);
    }
}
