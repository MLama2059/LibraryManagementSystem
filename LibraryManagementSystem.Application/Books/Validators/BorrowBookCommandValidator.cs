using FluentValidation;
using LibraryManagementSystem.Application.Loans.Commands;
using System;
using System.Collections.Generic;
using System.Text;

namespace LibraryManagementSystem.Application.Books.Validators
{
    public class BorrowBookCommandValidator : AbstractValidator<BorrowBookCommand>
    {
        public BorrowBookCommandValidator()
        {
            RuleFor(x => x.dto.BookId)
                .NotEmpty().WithMessage("Book Id is required for borrowing.")
                .GreaterThan(0).WithMessage("A valid Book Id is required for borrowing.");

            RuleFor(x => x.dto.MemberId)
                .NotEmpty().WithMessage("Member Id is required for borrowing.");

            RuleFor(x => x.dto.LoanDays)
                .GreaterThan(0).WithMessage("Loan duration must be at least 1 day.");
        }
    }
}
