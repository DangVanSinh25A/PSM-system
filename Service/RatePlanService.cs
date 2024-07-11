using HotelManagement.Dtos;
using HotelManagement.Models;
using HotelManagement.Repositories;
namespace HotelManagement.Sevice
{
         public interface IRatePlanService
        {
            RatePlan CreateRatePlan(RatePlan ratePlan);
            Task<RatePlanRes> GetRatePlansAsync(string? channelName, DateTime? dayStart, DateTime? dayEnd, string? roomTypeName, bool? status);
            RatePlanRes GetRatePlan(int id);
         

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

            public Task<RatePlanRes> GetRatePlansAsync(string? channelName, DateTime? dayStart, DateTime? dayEnd, string? roomTypeName, bool? status)
            {
                return _rateplanRepository.GetRatePlansAsync(channelName, dayStart, dayEnd, roomTypeName, status);
            }

            public RatePlanRes GetRatePlan(int id){
                var detailRatePlan = _rateplanRepository.GetRatePlan(id);
                return detailRatePlan; 
            }
        }
        
}