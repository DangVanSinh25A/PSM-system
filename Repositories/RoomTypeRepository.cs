using HotelManagement.Database;
using HotelManagement.Models;
namespace HotelManagement.Repositories
{

    public interface IRoomTypeRepository
    {
        RoomType CreateRoomType(RoomType roomType);
    }
    public class RoomTypeRepository : IRoomTypeRepository
    {
         private readonly AppDbContext _context;

        public RoomTypeRepository(AppDbContext context)
        {
            _context = context;
        }
        
        public RoomType CreateRoomType(RoomType roomtype)
        {
            _context.RoomTypes.Add(roomtype);
            _context.SaveChanges();
            return roomtype;
        }

    }
}