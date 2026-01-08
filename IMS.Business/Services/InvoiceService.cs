using FluentValidation;
using IMS.Business.Interface;
using IMS.Data.Interface;
using IMS.Data.Repository;
using IMS.Data.UoW;
using IMS.Models.DTOs;
using IMS.Models.Entities;
using IMS.Models.Enum;
using System;
using System.Collections.Generic;
using System.Text;

namespace IMS.Business.Services
{
    public class InvoiceService : IInvoiceService
    {
        public readonly IValidator<CreateInvoiceRequest> _invoicevalidator;
        public readonly IUnitOfWork _uow;
        public readonly IInvoiceRepository _invoiceRepository;
        public InvoiceService(IValidator<CreateInvoiceRequest> invoicevalidator, IUnitOfWork uow, IInvoiceRepository invoiceRepository) 
        { 
            _invoicevalidator = invoicevalidator;
            _uow = uow;
            _invoiceRepository = invoiceRepository; 
        }
        public async Task<InvoiceResponse> CreateAsync(CreateInvoiceRequest request)
        {
            var validationResult = await _invoicevalidator.ValidateAsync(request);
            if (validationResult != null)
            {
                throw new ValidationException(validationResult.Errors);
            }
            var invoice = new Invoice
            {
                CustomerName = request.CustomerName,
                InvoiceDate = request.InvoiceDate,
                Status = InvoiceStatus.Draft,
                InvoiceNumber = await GenerateInvoiceNumberAsync()
            };

            foreach (var line in request.Lines)
            {
                var sub = line.Quantity * line.UnitPrice;
                var tax = sub * line.TaxPercent / 100;

                invoice.InvoiceLines.Add(new InvoiceLine
                {
                    Description = line.Description,
                    Quantity = line.Quantity,
                    UnitPrice = line.UnitPrice,
                    TaxPercent = line.TaxPercent,
                    LineSubTotal = sub,
                    LineTax = tax,
                    LineTotal = sub + tax
                });
            }

            invoice.SubTotal = invoice.InvoiceLines.Sum(x => x.LineSubTotal);
            invoice.TaxTotal = invoice.InvoiceLines.Sum(x => x.LineTax);
            invoice.GrandTotal = invoice.SubTotal + invoice.TaxTotal;

            await _uow.Invoices.AddAsync(invoice);
            await _uow.SaveChangesAsync(); // transactional

            return new InvoiceResponse
            {
                Id = invoice.Id,
                InvoiceNumber = invoice.InvoiceNumber,
                GrandTotal = invoice.GrandTotal
            };
        }

        public async Task<InvoiceResponse?> GetByIdAsync(int id)
        {
            var invoice = await _uow.Invoices.GetByIdAsync(id);
            if (invoice == null) return null;

            return new InvoiceResponse
            {
                Id = invoice.Id,
                InvoiceNumber = invoice.InvoiceNumber,
                GrandTotal = invoice.GrandTotal
            };
        }

        private async Task<string> GenerateInvoiceNumberAsync()
        {
            int year = DateTime.UtcNow.Year;

            int lastNumber = await _invoiceRepository
               .GetMaxInvoiceSequenceAsync(year);

            int nextNumber = lastNumber + 1;

            return $"INV-{year}-{nextNumber:D5}";
        }
    }
}

