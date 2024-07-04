using HotelManagement.Models;
using Microsoft.EntityFrameworkCore;
namespace HotelManagement.Database
{
    public class AppDbContext : DbContext
    {
        public DbSet<Seller> Sellers { get; set; }
        public DbSet<Hotel> Hotels { get; set; }
        public DbSet<RoomType> RoomTypes { get; set; }
        public DbSet<Room> Rooms { get; set; }
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

         protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Seller>()
                .HasOne(s => s.Hotel)
                .WithMany()
                .HasForeignKey(s => s.HotelId);

            modelBuilder.Entity<RoomType>()
                .HasOne(s => s.Hotel)
                .WithMany()
                .HasForeignKey(s => s.HotelId);

            modelBuilder.Entity<Room>()
                .HasOne(s => s.RoomType)
                .WithMany()
                .HasForeignKey(s => s.RoomTypeId);
        }
    }
}