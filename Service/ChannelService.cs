using HotelManagement.Models;
using HotelManagement.Repositories;
namespace HotelManagement.Sevice
{
         public interface IChannelService
        {
            Channel CreateChannel(Channel channel);
        }

        public class ChannelService : IChannelService
        {
            private readonly IChannelRepository _channelRepository;

            public ChannelService(IChannelRepository channelRepository)
            {
                _channelRepository = channelRepository;
            }

            public Channel CreateChannel(Channel channel)
            {
                return _channelRepository.CreateChannel(channel);
            }
    }
}