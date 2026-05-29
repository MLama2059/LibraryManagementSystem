using LibraryManagementSystem.Domain.Entities;
using LibraryManagementSystem.Domain.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace LibraryManagementSystem.Application.Loans.Commands
{
    public class BorrowBookHandler(IUnitOfWork _unitOfWork) : IRequestHandler<BorrowBookCommand, bool>
    {
        public async Task<bool> Handle(BorrowBookCommand request, CancellationToken cancellationToken)
        {
            var existingBook = await _unitOfWork.Books.GetBookByIdAsync(request.dto.BookId);
            if (existingBook == null || existingBook.AvailableCopies <= 0)
            {
                return false;
            }

            existingBook.AvailableCopies--;

            var loan = new Loan
            {
                BookId = request.dto.BookId,
                MemberId = request.dto.MemberId,
                BorrowDate = DateTime.UtcNow,
                DueDate = DateTime.UtcNow.AddDays(request.dto.LoanDays),
                IsReturned = false
            };

            await _unitOfWork.Loans.AddLoanAsync(loan);
            await _unitOfWork.SaveChangesAsync();

            return true;
        }
    }
}
