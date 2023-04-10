using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Catalog.DAL.Models
{
    public class Item
    {
        [Key]
        public int Id { get; set; }
    
        [Required]
        [MaxLength(50)]
        public string Name { get; set; }
    
        public string Description { get; set; }
    
        public string ImageUrl { get; set; }
    
        [Required]
        public decimal Price { get; set; }
    
        [Required]
        public int Amount { get; set; }
    
        [Required]
        public int CategoryId { get; set; }
    
        [ForeignKey("CategoryId")]
        public Category Category { get; set; }
    }
}