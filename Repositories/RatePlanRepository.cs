using HotelManagement.Database;
using HotelManagement.Dtos;
using HotelManagement.Models;
using Microsoft.EntityFrameworkCore;
namespace HotelManagement.Repositories
{

    public interface IRatePlanRepository
    {
        RatePlan CreateRatePlan(RatePlan ratePlan);

        Task<List<RatePlan>> GetRatePlansAsync(string? channelName, DateTime? dayStart, DateTime? dayEnd, string? roomTypeName, bool? status);
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

        public async Task<List<RatePlan>> GetRatePlansAsync(string? channelName, DateTime? dayStart, DateTime? dayEnd, string? roomTypeName, bool? status)
        {
            var listRatePlan = _context.RatePlans.AsQueryable();

            if (channelName != null)
            {
                var channel = await _context.Channels
                    .FirstOrDefaultAsync(rp => rp.Name == channelName);
                var id = channel.Id;
                var ratePlans = await _context.RatePlans
                .Where(rp => rp.ChannelId == id)
                .ToListAsync();
            }

            if (dayStart != null && dayEnd != null)
            {
                listRatePlan = listRatePlan.Where(b => b.Daystart >= dayStart && b.DayEnd <= dayEnd);
            }

            if (roomTypeName != null)
            {
                var roomType = await _context.RoomTypes
                    .FirstOrDefaultAsync(rp => rp.Name == roomTypeName);
                var id = roomType.Id;
                var ratePlans = await _context.RatePlans
                .Where(rp => rp.ChannelId == id)
                .ToListAsync();
            }

            if (status != null)
            {
                listRatePlan = listRatePlan.Where(b => b.Status == status);
            }

            var ratePlan = await listRatePlan
                .ToListAsync();

            var ratePlanFilterRes = ratePlan.Select(b => new RatePlan
            {
                Name = b.Name,
                Price = b.Price,
                Daystart = b.Daystart,
                DayEnd = b.DayEnd,
                OccupancyLimit = b.OccupancyLimit,
                Channel = _context.Channels.FirstOrDefault(rp => rp.Id == b.ChannelId),
                PaymentConstraint = _context.PaymentConstraints.FirstOrDefault(rp => rp.Id == b.PaymentConstraintId),
                RoomType = _context.RoomTypes.FirstOrDefault(rp => rp.Id == b.RoomTypeId),
                CancelPolicy = _context.CancelPolicys.FirstOrDefault(rp => rp.Id == b.CancelPolicyId),
                Status = b.Status
            }).ToList();

            return ratePlanFilterRes;

        }

    }
}