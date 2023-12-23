using Microsoft.EntityFrameworkCore;
using PropertyWebApp.Models;

namespace PropertyWebApp.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {}
        public DbSet<User> Users { get; set; }
        public DbSet<Property> Properties { get; set; }
        public DbSet<FavouriteProperty> FavouriteProperties { get; set; }
        public DbSet<UserProfile> UserProfiles { get; set; }
        public DbSet<PropertyImage> PropertyImages { get; set; }

    }
}
