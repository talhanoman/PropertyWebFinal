using System.ComponentModel.DataAnnotations;

namespace PropertyWebApp.Models
{
    public class PropertyImage
    {
        [Key]
        public int Id { get; set; }
        public int PropertyId { get; set; }
        public string ImageUrl { get; set; }

        // Navigation property
        public Property Property { get; set; }
    }
}
