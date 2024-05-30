using System.ComponentModel.DataAnnotations;

namespace InvoicingSystem.DTOs
{
    public class CartItemDto
    {
        [Required]
        public int ProductId { get; set; }
        [Required(ErrorMessage = "Quantity is required")]
        [Range(1, int.MaxValue, ErrorMessage = "Quantity must be greater than zero")]
        public int Quantity { get; set; }
    }
}
