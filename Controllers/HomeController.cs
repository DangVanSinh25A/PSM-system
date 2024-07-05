using Microsoft.AspNetCore.Mvc;
using HotelManagement.Dtos;
using HotelManagement.Database;

namespace HotelManagement.Controllers
{
    [ApiController]
    [Route("api/home")]
     public class HomeController : Controller
    {

        private readonly AppDbContext _dbContext;

        public HomeController(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [Route("/home")]
        public IActionResult Home(){
            return View();
        }
        
  
       
    }
}