using FluentValidation;
using IMS.Models.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace IMS.Business.Validators
{
    public class CreateInvoiceLineValidator : AbstractValidator<CreateInvoiceLineRequest>
    {
        public CreateInvoiceLineValidator()
        {
            RuleFor(x => x.Description)
                .NotEmpty()
                .MaximumLength(200)
                .WithMessage("Details of the Item is missing");
            RuleFor(x => x.Quantity)
                .GreaterThan(0)
                .WithMessage("Enter the Quantity required");
            RuleFor(x => x.UnitPrice)
                .GreaterThan(0)
                .WithMessage("Price Invalid");
            RuleFor(x => x.TaxPercent)
                .InclusiveBetween(0, 100)
                .WithMessage("Enter a Valid Tax %");
        }
    }
}
