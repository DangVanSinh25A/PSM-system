using HotelManagement.Dtos;
using HotelManagement.Models;
using HotelManagement.Repositories;
namespace HotelManagement.Sevice
{
         public interface IRatePlanService
        {
            RatePlan CreateRatePlan(RatePlan ratePlan);
            Task<List<RatePlan>> GetRatePlansAsync(string? channelName, DateTime? dayStart, DateTime? dayEnd, string? roomTypeName, bool? status);

        }

        public class RatePlanService : IRatePlanService
        {
            private readonly IRatePlanRepository _rateplanRepository;

            public RatePlanService(IRatePlanRepository rateplanRepository)
            {
                _rateplanRepository = rateplanRepository;
            }

            public RatePlan CreateRatePlan(RatePlan ratePlan)
            {
                return _rateplanRepository.CreateRatePlan(ratePlan);
            }

            public Task<List<RatePlan>> GetRatePlansAsync(string? channelName, DateTime? dayStart, DateTime? dayEnd, string? roomTypeName, bool? status)
            {
                return _rateplanRepository.GetRatePlansAsync(channelName, dayStart, dayEnd, roomTypeName, status);
            }
        }
        
}