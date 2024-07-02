using Microsoft.AspNetCore.Mvc;
namespace HotelManagement.Controllers
{
     public class LoginController : Controller
    {
        [Route("/login")]
        public IActionResult Login(){
            return View();
        }
    }
}