using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PropertyWebApp.Models
{
    public class Property
    {
        [Key]
        public int Id { get; set; }
        public int OwnerId { get; set; }
        [Required]
        public string Address { get; set; }
        [Required]        
        [Column(TypeName = "decimal(18,4)")]
        public decimal Price { get; set; }
        [Required]
        public int SquareFootage { get; set; }
        [Required]
        public int Bedrooms { get; set; }
        [Required]    
        public string PropertyType { get; set; }
        public string Description { get; set; }


        public ICollection<PropertyImage> Images { get; set; }
        public DateTime? DateListed { get; set; } = DateTime.Now;

        // Navigation properties
        public User? Owner { get; set; }
        public ICollection<FavouriteProperty>? FavouriteByUsers { get; set; }        
    }
}
