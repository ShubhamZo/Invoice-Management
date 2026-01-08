using IMS.Models.DTOs;

namespace IMS.Business.Interface
{
    public interface IInvoiceService
    {
        Task<InvoiceResponse> CreateAsync(CreateInvoiceRequest request);
        Task<InvoiceResponse?> GetByIdAsync(int id);
    }
}
