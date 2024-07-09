using HotelManagement.Database;
using HotelManagement.Models;
namespace HotelManagement.Repositories
{

    public interface IChannelRepository
    {
        Channel CreateChannel(Channel channel);
    }
    public class ChannelRepository : IChannelRepository
    {
         private readonly AppDbContext _context;

        public ChannelRepository(AppDbContext context)
        {
            _context = context;
        }
        
        public Channel CreateChannel(Channel channel)
        {
            _context.Channels.Add(channel);
            _context.SaveChanges();
            return channel;
        }

    }
}