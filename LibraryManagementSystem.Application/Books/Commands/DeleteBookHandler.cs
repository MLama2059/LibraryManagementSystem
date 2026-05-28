using LibraryManagementSystem.Domain.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace LibraryManagementSystem.Application.Books.Commands
{
    public class DeleteBookHandler(IUnitOfWork _unitOfWork) : IRequestHandler<DeleteBookCommand, bool>
    {
        public async Task<bool> Handle(DeleteBookCommand request, CancellationToken cancellationToken)
        {
            var existingBook = await _unitOfWork.Books.GetBookByIdAsync(request.id);

            if (existingBook == null)
            {
                return false;
            }

            _unitOfWork.Books.DeleteBook(existingBook);
            await _unitOfWork.SaveChangesAsync();
            return true;
        }
    }
}
