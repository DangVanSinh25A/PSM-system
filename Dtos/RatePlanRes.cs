using HotelManagement.Models;
namespace HotelManagement.Dtos
{
    public class RatePlanRes
    {
        public required List<RatePlan> RatePlans { get; set; }
        public required string Message { get; set; }
    }
}