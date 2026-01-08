using IMS.Data.Context;
using IMS.Data.Interface;
using IMS.Data.Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace IMS.Data.UoW
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _context;
        public IInvoiceRepository Invoices { get; }

        public UnitOfWork(AppDbContext context)
        {
            _context = context;
            Invoices = new InvoiceRepository(context);
        }

        public Task<int> SaveChangesAsync()
            => _context.SaveChangesAsync();
    }
}
