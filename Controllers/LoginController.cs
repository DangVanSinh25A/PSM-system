using Microsoft.AspNetCore.Mvc;
using HotelManagement.Dtos;
using HotelManagement.Database;

namespace HotelManagement.Controllers
{
    [ApiController]
    [Route("api/login")]
     public class LoginController : Controller
    {

        private readonly AppDbContext _dbContext;

        public LoginController(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [Route("/login")]
        public IActionResult Login(){
            return View();
        }
        [HttpPost]
        public IActionResult Login(Login request)
        {
            var errors = new Dictionary<string, string[]>();
            if (string.IsNullOrWhiteSpace(request.Email))
                errors["Email"] = new[] { "Email must be a non-empty string" };
            if (string.IsNullOrWhiteSpace(request.Password))
                errors["Password"] = new[] { "Password must be a non-empty string" };

            var seller = _dbContext.Sellers.FirstOrDefault(s => s.Email == request.Email);
            
            if(seller == null){
                errors["Email"] = new[] { "Email error" };
                return BadRequest(new { errors });
            }

            if(seller.Password != request.Password){
                errors["Password"] = new[] { "Password error" };
            }

            if (errors.Any())
            return BadRequest(new { errors });

            return CreatedAtAction(nameof(GetSeller), new { id = seller.Id }, seller);

        }
        [HttpGet("{id}")]
        public IActionResult GetSeller(int id)
        {
            var seller = _dbContext.Sellers.Find(id);
            if (seller == null)
                return NotFound();

            return Ok(seller);
        }
    }
}