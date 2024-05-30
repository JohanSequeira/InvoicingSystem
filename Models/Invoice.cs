using InvoicingSystem.DTOs;

namespace InvoicingSystem.Models
{
    public class Invoice
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public List<InvoiceItem> Items { get; set; }
        public decimal Subtotal { get; set; }
        public decimal Discount { get; set; }
        public decimal Tax { get; set; }
        public decimal Total { get; set; }
        public string PaymentOption { get; set; }
        public DateTime Date { get; set; }
    }


}
