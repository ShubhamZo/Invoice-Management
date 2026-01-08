using FluentValidation;
using IMS.Models.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace IMS.Business.Validators
{
    public class CreateInvoiceValidator : AbstractValidator<CreateInvoiceRequest>
    {
        public CreateInvoiceValidator()
        {
            RuleFor(x => x.CustomerName)
                .NotEmpty()
                .Length(2, 100);
            RuleFor(x => x.InvoiceDate)
                .NotEmpty()
                .LessThanOrEqualTo(DateTime.Now)
                .WithMessage("Enter correct Date");
            RuleFor(x => x.Lines)
                .NotEmpty()
                .WithMessage("At least one line is required");
            RuleForEach(x => x.Lines)
                .SetValidator(new CreateInvoiceLineValidator());
        }
    }

}
