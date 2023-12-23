using System.ComponentModel.DataAnnotations;

namespace PropertyWebApp.Models
{
    public class UserProfile
    {
        [Key]
        public int Id { get; set; }
        public int UserId { get; set; }
        public string Name { get; set; }
        public string PhoneNumber { get; set; }
        public string ProfilePictureUrl { get; set; }

        // Navigation property
        public User User { get; set; }
    }
}
