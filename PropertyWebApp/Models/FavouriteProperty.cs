using System.ComponentModel.DataAnnotations;

namespace PropertyWebApp.Models
{
    public class FavouriteProperty
    {
        [Key]
        public int FavouritePropertyId {get; set;}
        public int UserId { get; set; }
        public int PropertyId { get; set; }

        // Navigation properties
        public User User { get; set; }
        public Property Property { get; set; }
    }
}
