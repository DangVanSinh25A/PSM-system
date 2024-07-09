using Microsoft.AspNetCore.Mvc;
using HotelManagement.Dtos;
using HotelManagement.Models;
using HotelManagement.Sevice;
namespace HotelManagement.Controllers
{
    [ApiController]
    [Route("api/cancelpolicy")]
    public class CancelPolicyController : Controller
    {
        private readonly ICancelPolicyService _cancelpolicyService;

        public CancelPolicyController(ICancelPolicyService cancelpolicyService)
        {
            _cancelpolicyService = cancelpolicyService;
        }

        [HttpPost]
        public IActionResult CreateCancelPolicy(CreateCancelPolicyRequest request)
        {
            var cancelpolicy = new CancelPolicy
            {
                Name = request.Name,
                Description = request.Description,
            };

            var createdCancelPolicy = _cancelpolicyService.CreateCancelPolicy(cancelpolicy); 

            return Ok(createdCancelPolicy);
        }
    }
}