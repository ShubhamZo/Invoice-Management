using IMS.Models.DTOs;
using IMS.Models.Entities;

namespace IMS.Business.Interface
{
    public interface IInvoiceService
    {
        Task<List<InvoiceResponse>> GetAllAsync();
        Task<InvoiceResponse> CreateAsync(CreateInvoiceRequest request);
        Task<InvoiceResponse?> GetByIdAsync(int id);
        Task<DeleteInvoiceResponse?> SoftDeleteAsync(int id);
    }
}
