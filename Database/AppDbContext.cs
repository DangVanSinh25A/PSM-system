using HotelManagement.Models;
using Microsoft.EntityFrameworkCore;
namespace HotelManagement.Database
{
    public class AppDbContext : DbContext
    {
        public DbSet<Seller> Sellers { get; set; }
        public DbSet<Hotel> Hotels { get; set; }
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }
    }
}