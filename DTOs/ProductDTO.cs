using System.ComponentModel.DataAnnotations;

namespace InvoicingSystem.DTOs
{
    public class ProductDTO
    {
        [Required]
        public string Name { get; set; }
        public string Description { get; set; }
        [Range(0.01, double.MaxValue)]
        public decimal Price { get; set; }
        [Range(1, int.MaxValue)]
        public int Quantity { get; set; }
        public int CategoryId { get; set; }
        //public Category Category { get; set; }
        public decimal DiscountPercentage { get; set; }
    }

}
