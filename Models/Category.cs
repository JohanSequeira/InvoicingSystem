using System.ComponentModel.DataAnnotations;
namespace InvoicingSystem.Models
{    

    public class Category
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Name is required")]
        [StringLength(100, ErrorMessage = "Name length can't be more than 100.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Description is required")]
        [StringLength(500, ErrorMessage = "Description length can't be more than 500.")]
        public string Description { get; set; }
    }


}
