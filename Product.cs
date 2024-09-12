using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ITIProject.Models
{
    public class Product
    {
        public int ProductId { get; set; }
        [Required]
        [StringLength(20)]
        public string Title { get; set; }
        [Required]

        [Column(TypeName = "decimal(10,3)")]
        public decimal Price { get; set; }
        public string Description { get; set; }
        [Required]
        [Range(0, 50)]
        public int Quantity { get; set; }
        public string ImagePath { get; set; }

        public int CategoryId { get; set; }

        public virtual Category? Category { get; set; }
    }
}
