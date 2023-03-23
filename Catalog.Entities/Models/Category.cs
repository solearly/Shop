using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Catalog.DAL.Models
{
    public class Category
    {
        [Key]
        public int Id { get; set; }
    
        [Required]
        [MaxLength(50)]
        public string Name { get; set; }
    
        public string ImageUrl { get; set; }
    
        public int? ParentCategoryId { get; set; }
    
        [ForeignKey("ParentCategoryId")]
        public Category ParentCategory { get; set; }
    
        public ICollection<Item> Items { get; set; }
        public ICollection<Category> Subcategories { get; set; }
    }
}