namespace InvoicingSystem.DTOs
{
    public class InvoiceRequestDTO
    {
        public int CustomerId { get; set; }
        public List<CartItemDto> Cart { get; set; }
        public decimal FlatDiscount { get; set; }
        public string PaymentOption { get; set; }
    }
}
