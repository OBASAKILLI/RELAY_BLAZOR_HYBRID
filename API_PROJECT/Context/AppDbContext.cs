using Microsoft.EntityFrameworkCore;

namespace API_PROJECT.Context
{
    public class AppDbContext:DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }
        public DbSet<API_PROJECT.Models.Ads> ads { get; set; }

        public DbSet<API_PROJECT.Models.Categories>  Categories { get; set; }

        public DbSet<API_PROJECT.Models.Countries> countries { get; set; }

        public DbSet<API_PROJECT.Models.Products> products { get; set; }

        public DbSet<API_PROJECT.Models.Shop_Connects> shop_Connects { get; set; }

        public DbSet<API_PROJECT.Models.Shops> shops { get; set; }

        public DbSet<API_PROJECT.Models.Sub_Categories> sub_Categories { get; set; }

        public DbSet<API_PROJECT.Models.Users> Users { get; set; }

    }
}
