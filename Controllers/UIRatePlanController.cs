using Microsoft.AspNetCore.Mvc;
using HotelManagement.Models;
using HotelManagement.Dtos;
using HotelManagement.Sevice;
namespace HotelManagement.Controllers
{
    [ApiController]
    [Route("api/ratePlan")]
    public class UIRateController : Controller
    {
        [Route("/ratePlan")]
        public IActionResult RatePlan()
        {
            return View();  
        }

    }
}