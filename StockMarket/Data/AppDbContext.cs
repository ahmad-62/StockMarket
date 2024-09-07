using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using StockMarket.Models;

namespace StockMarket.Data
{
    public class AppDbContext:IdentityDbContext<ApplicationUser>
    {
        public AppDbContext()
        {

        }
        public AppDbContext(DbContextOptions options):base(options) { }
        public DbSet<Stock> stocks { get; set; }
        public DbSet<Comment> comments { get; set; }
        public DbSet<Protfolio> protfolios { get; set; }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            //List<IdentityRole> roles = new List<IdentityRole>()
            //{
            //    new IdentityRole{Name="Admin",NormalizedName="ADMIN"},
            //    new IdentityRole{Name="User",NormalizedName="USER"}
            //};
            //builder.Entity<IdentityRole>().HasData(roles);
            builder.Entity<Protfolio>(x => x.HasKey(k => new { k.StockId, k.ApplicationuserId }));
        }
    }
}
