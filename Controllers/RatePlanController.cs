using Microsoft.AspNetCore.Mvc;
using HotelManagement.Dtos;
using HotelManagement.Models;
using HotelManagement.Sevice;
namespace HotelManagement.Controllers
{
    [ApiController]
    [Route("api/rate-plan")]
    public class RatePlanController : Controller
    {
        private readonly IRatePlanService _rateplanService;

        public RatePlanController(IRatePlanService rateplanService)
        {
            _rateplanService = rateplanService;
        }

        [HttpPost]
        public IActionResult CreateRatePlan(CreateRatePlanRequest request)
        {
            var ratePlan = new RatePlan
            {
                Name = request.Name,
                Price = request.Price,
                Daystart = request.DayStart,
                DayEnd = request.DayEnd,
                OccupancyLimit = request.OccupancyLimit,
                ChannelId = request.ChannelId,
                PaymentConstraintId = request.PaymentConstraintId,
                CancelPolicyId = request.CancelPolicyId,
                RoomTypeId = request.RoomTypeId,
                Status = Convert.ToBoolean(1)
            };

            var createdRatePlan = _rateplanService.CreateRatePlan(ratePlan); 

            return Ok(createdRatePlan);
        }

        [HttpGet]
    public async Task<ActionResult<List<RatePlanFilterRes>>> GetRatePlans(
        [FromQuery] string? channelName, [FromQuery] DateTime? dayStart, [FromQuery] DateTime? dayEnd, 
        [FromQuery] string? roomTypeName, [FromQuery] bool? status)
    {
        var ratePlans = await _rateplanService.GetRatePlansAsync(channelName, dayStart, dayEnd, roomTypeName, status);
        return ratePlans;
    }
    }
}
