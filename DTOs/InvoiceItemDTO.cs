using System.ComponentModel.DataAnnotations;

namespace InvoicingSystem.DTOs
{
    public class InvoiceItemDTO
    {
        //public int ProductId { get; set; }
        public string ProductName { get; set; }
        [Range(1, int.MaxValue)]
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        public decimal Discount { get; set; }
    }

}
