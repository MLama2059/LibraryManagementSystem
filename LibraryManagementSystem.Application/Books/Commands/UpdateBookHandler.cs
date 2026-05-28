using LibraryManagementSystem.Domain.Entities;
using LibraryManagementSystem.Domain.Interfaces;
using MediatR;
using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Text;

namespace LibraryManagementSystem.Application.Books.Commands
{
    public class UpdateBookHandler(IUnitOfWork _unitOfWork) : IRequestHandler<UpdateBookCommand, bool>
    {
        public async Task<bool> Handle(UpdateBookCommand request, CancellationToken cancellationToken)
        {
            var existingBook = await _unitOfWork.Books.GetBookByIdAsync(request.id);
            if (existingBook == null)
            {
                return false;
            }

            // Calculate the inventory delta (difference)
            int totalCopiesDelta = request.dto.TotalCopies - existingBook.TotalCopies;

            existingBook.Title = request.dto.Title;
            existingBook.Author = request.dto.Author;
            existingBook.ISBN = request.dto.ISBN;
            existingBook.Genre = request.dto.Genre;
            existingBook.TotalCopies = request.dto.TotalCopies;
            // Apply the delta safely to your live balance
            existingBook.AvailableCopies += totalCopiesDelta;

            _unitOfWork.Books.UpdateBook(existingBook);
            await _unitOfWork.SaveChangesAsync();
            return true;
        }
    }
}
