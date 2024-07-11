using HotelManagement.Database;
using HotelManagement.Dtos;
using HotelManagement.Models;
using Microsoft.EntityFrameworkCore;
namespace HotelManagement.Repositories
{

    public interface IRatePlanRepository
    {
        RatePlan CreateRatePlan(RatePlan ratePlan);

        Task<RatePlanRes> GetRatePlansAsync(string? channelName, DateTime? dayStart, DateTime? dayEnd, string? roomTypeName, bool? status);
        RatePlanRes GetRatePlan(int id);
        
    }
    public class RatePlanRepository : IRatePlanRepository
    {
         private readonly AppDbContext _context;

        public RatePlanRepository(AppDbContext context)
        {
            _context = context;
        }
        
        public RatePlan CreateRatePlan(RatePlan ratePlan)
        {
            _context.RatePlans.Add(ratePlan);
            _context.SaveChanges();
            return ratePlan;
        }

        public async Task<RatePlanRes> GetRatePlansAsync(string? channelName, DateTime? dayStart, DateTime? dayEnd, string? roomTypeName, bool? status)
        {
            var listRatePlan = _context.RatePlans.AsQueryable();

            if (!string.IsNullOrEmpty(channelName))
            {
                var channel = await _context.Channels.FirstOrDefaultAsync(c => c.Name == channelName);
                if (channel != null)
                {
                    listRatePlan = listRatePlan.Where(rp => rp.ChannelId == channel.Id);
                }
            }

            if (dayStart != null && dayEnd != null)
            {
                listRatePlan = listRatePlan.Where(b => b.Daystart >= dayStart && b.DayEnd <= dayEnd);
            }

            if (!string.IsNullOrEmpty(roomTypeName))
            {
                var roomType = await _context.RoomTypes.FirstOrDefaultAsync(rt => rt.Name == roomTypeName);
                if (roomType != null)
                {
                    listRatePlan = listRatePlan.Where(rp => rp.RoomTypeId == roomType.Id);
                }
            }

            if (status != null)
            {
                listRatePlan = listRatePlan.Where(b => b.Status == status);
            }

            var ratePlanList = await listRatePlan.ToListAsync();

            if (ratePlanList == null || !ratePlanList.Any())
            {
                return new RatePlanRes
                {
                    RatePlans = new List<RatePlan>(),
                    Message = "There is no data that matches what you want."
                };
            }

            var ratePlanFilterRes = ratePlanList.Select(b => new RatePlan
            {
                Id = b.Id,
                Name = b.Name,
                Price = b.Price,
                Daystart = b.Daystart,
                DayEnd = b.DayEnd,
                OccupancyLimit = b.OccupancyLimit,
                ChannelId = b.ChannelId,
                PaymentConstraintId = b.PaymentConstraintId,
                RoomTypeId = b.RoomTypeId,
                CancelPolicyId = b.CancelPolicyId,
                Channel = _context.Channels.FirstOrDefault(rp => rp.Id == b.ChannelId),
                PaymentConstraint = _context.PaymentConstraints.FirstOrDefault(rp => rp.Id == b.PaymentConstraintId),
                RoomType = _context.RoomTypes.FirstOrDefault(rp => rp.Id == b.RoomTypeId),
                CancelPolicy = _context.CancelPolicys.FirstOrDefault(rp => rp.Id == b.CancelPolicyId),
                Status = b.Status
            }).ToList();

            return new RatePlanRes
            {
                RatePlans = ratePlanFilterRes,
                Message = "Data retrieved successfully."
            };
        }

        public RatePlanRes GetRatePlan(int id)
        {
            var ratePlan = _context.RatePlans.Find(id);
            
            if (ratePlan == null)
            {
                return new RatePlanRes
                {
                    RatePlans = new List<RatePlan>(),
                    Message = "RatePlan not found."
                };
            }

            var detailRatePlan = new RatePlan
            {
                Id = ratePlan.Id,
                Name = ratePlan.Name,
                Price = ratePlan.Price,
                Daystart = ratePlan.Daystart,
                DayEnd = ratePlan.DayEnd,
                OccupancyLimit = ratePlan.OccupancyLimit,
                ChannelId = ratePlan.ChannelId,
                PaymentConstraintId = ratePlan.PaymentConstraintId,
                RoomTypeId = ratePlan.RoomTypeId,
                CancelPolicyId = ratePlan.CancelPolicyId,
                Channel = _context.Channels.FirstOrDefault(rp => rp.Id == ratePlan.ChannelId),
                PaymentConstraint = _context.PaymentConstraints.FirstOrDefault(rp => rp.Id == ratePlan.PaymentConstraintId),
                RoomType = _context.RoomTypes.FirstOrDefault(rp => rp.Id == ratePlan.RoomTypeId),
                CancelPolicy = _context.CancelPolicys.FirstOrDefault(rp => rp.Id == ratePlan.CancelPolicyId),
                Status = ratePlan.Status
            };

            return new RatePlanRes
            {
                RatePlans = new List<RatePlan> { detailRatePlan },
                Message = "Data retrieved successfully."
            };
        }
    }
}