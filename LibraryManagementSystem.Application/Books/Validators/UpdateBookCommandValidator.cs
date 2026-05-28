using FluentValidation;
using LibraryManagementSystem.Application.Books.Commands;
using System;
using System.Collections.Generic;
using System.Text;

namespace LibraryManagementSystem.Application.Books.Validators
{
    public class UpdateBookCommandValidator : AbstractValidator<UpdateBookCommand>
    {
        public UpdateBookCommandValidator()
        {       
            RuleFor(x => x.id)
                .NotEmpty().WithMessage("Book Id is required for update.")
                .GreaterThan(0).WithMessage("A valid book Id is required for update.");

            RuleFor(x => x.dto.Title)
                 .NotEmpty().WithMessage("Title is required.")
                 .MaximumLength(200).WithMessage("Title cannot exceed 200 characters.");

            RuleFor(x => x.dto.Author)
                .NotEmpty().WithMessage("Author name is required.")
                .MaximumLength(100).WithMessage("Author name cannot exceed 100 characters.");

            RuleFor(x => x.dto.ISBN)
                .NotEmpty().WithMessage("ISBN registration code is required.")
                .MaximumLength(20).WithMessage("ISBN cannot exceed 20 characters."); ;

            RuleFor(x => x.dto.Genre)
                .NotEmpty().WithMessage("Genre classification is required.");

            RuleFor(x => x.dto.TotalCopies)
                .GreaterThan(0).WithMessage("Total inventory copies must be at least 1.");
        }
    }
}
