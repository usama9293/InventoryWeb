using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;

namespace Inventory.Models
{
    public class Product
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Title{ get; set; }

        public string Description { get; set; }

        [Required]

        public string Author { get; set; }

        [Required]
        public string ISBN { get; set; }
        [Required]
        [DisplayName("list Price")]
        [Range(1, 1000, ErrorMessage = "Price must be between 0 and 10000.")]
        public int listPrice { get; set; }

        [Required]
        [DisplayName("Price 1 to 50")]
        [Range(1, 1000, ErrorMessage = "Price must be between 1 and 50.")]
        public int Price { get; set; }

        [Required]
        [DisplayName("Price for 50+")]
        [Range(1, 1000, ErrorMessage = "Price must be between 51 and 100.")]
        public int Price50 { get; set; }
        [Required]
        [DisplayName("Price for 100+")]
        [Range(1, 1000, ErrorMessage = "Price must be between 101 and 1000.")]
        public int Price100 { get; set; }

        [Required]
        public int CategoryId { get; set; }

        // Navigation property to Category
        public Category Category { get; set; }

        public string ImageUrl { get; set; }

    }
}
