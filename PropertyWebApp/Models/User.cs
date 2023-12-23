using System.ComponentModel.DataAnnotations;

namespace PropertyWebApp.Models
{
    public class User
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
        public DateTime? CreatedAt { get; set; } = DateTime.Now;

        // Navigation properties (optional)
        public UserProfile? Profile { get; set; }
        public ICollection<FavouriteProperty>? FavouriteProperties { get; set; }        
    }
}
