using InvoicingSystem.DTOs;
using InvoicingSystem.Models;

namespace InvoicingSystem.Services
{
    public interface IInvoiceService
    {
        Task<InvoiceDTO> GenerateInvoiceAsync(InvoiceRequestDTO request);
    }

}
