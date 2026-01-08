using IMS.Data.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace IMS.Data.UoW
{
    public interface IUnitOfWork
    {
        IInvoiceRepository Invoices { get; }
        Task<int> SaveChangesAsync();
    }
}
