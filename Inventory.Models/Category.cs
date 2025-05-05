using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Inventory.Models
{
    public class Category
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "Name is required.")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Name must be between 3 and 50 characters.")]
        [DisplayName("Category Name")]
      
        public string Name { get; set; }

        [Required(ErrorMessage = "Description is required.")]
        [StringLength(200, MinimumLength = 5, ErrorMessage = "Description must be between 5 and 200 characters.")]
        public string Description { get; set; }
        public ICollection<Product> Products { get; set; }

    }
}
