using InvoicingSystem.Models;

namespace InvoicingSystem.DTOs
{
    public class InvoiceDTO
    {
        public int CustomerId { get; set; }
        public List<InvoiceItemDTO> Items { get; set; }
        public decimal Subtotal { get; set; }
        public decimal Discount { get; set; }
        public decimal Tax { get; set; }
        public decimal Total { get; set; }
        public string PaymentOption { get; set; }
    }

}
