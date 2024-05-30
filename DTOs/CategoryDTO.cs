using System.ComponentModel.DataAnnotations;

namespace InvoicingSystem.DTOs
{
    public class CategoryDTO
    {
        [Required(ErrorMessage = "Name is required")]
        [StringLength(100, ErrorMessage = "Name length can't be more than 100.")]
        public string Name { get; set; }
        public string Description { get; set; }
    }

}
