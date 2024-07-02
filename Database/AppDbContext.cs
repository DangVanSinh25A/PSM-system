using HotelManagement.Models;
using Microsoft.EntityFrameworkCore;
namespace HotelManagement.Database
{
    public class AppDbContext : DbContext
    {
        public DbSet<Seller> Seller { get; set; }
        public DbSet<Hotel> Hotel { get; set; }
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }
    }
}