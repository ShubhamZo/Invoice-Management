using IMS.Data.Context;
using IMS.Data.Interface;
using IMS.Models.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace IMS.Data.Repository
{
    public class InvoiceRepository : IInvoiceRepository
    {
        private readonly AppDbContext _context;

        public InvoiceRepository(AppDbContext context)
        {
            _context = context;
        }
        public async Task<List<Invoice>> GetAllAsync()
        {
            return await _context.Invoices.Include(x => x.InvoiceLines).ToListAsync();
        }
        public async Task AddInvoiceAsync(Invoice invoice)
            => await _context.Invoices.AddAsync(invoice);

        public async Task<Invoice?> GetByIdAsync(int id)
        {
            return await _context.Invoices.FirstOrDefaultAsync(x => x.Id == id);
        }
        public async Task<int> GetMaxInvoiceSequenceAsync(int year)
        {
            var prefix = $"INV-{year}-";

            var lastInvoice = await _context.Invoices
                .Where(i => i.InvoiceNumber.StartsWith(prefix))
                .OrderByDescending(i => i.InvoiceNumber)
                .Select(i => i.InvoiceNumber)
                .FirstOrDefaultAsync();

            if (lastInvoice == null)
                return 0;

            return int.Parse(lastInvoice.Split('-')[2]);
        }
    }

}
