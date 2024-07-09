using System;
using System.ComponentModel.DataAnnotations;

namespace HotelManagement.Dtos
{
    public class RatePlanFilterRes
    {
        public required string Name { get; set; }
        public int Price { get; set; }
        public DateTime DayStart { get; set; }
        public DateTime DayEnd { get; set; }
        public int OccupancyLimit { get; set; }
        public required object Channel { get; set; }
        public required object PaymentConstraint { get; set; }
        public required object CancelPolicy { get; set; }
        public required object RoomType { get; set; }
        public bool Status { get; internal set; }
    }
}
