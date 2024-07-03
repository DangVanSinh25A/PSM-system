using Microsoft.AspNetCore.Mvc;
using HotelManagement.Database;
using HotelManagement.Dtos;
using HotelManagement.Models;


namespace HotelManagement.Controllers
{

    [ApiController]
    [Route("api/hotel")]
    public class HotelController : Controller
    {
        private readonly AppDbContext _dbContext;

        public HotelController(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

    [HttpPost]
    public IActionResult CreateHotel(CreateHotelRequest request)
    {
        var errors = new Dictionary<string, string[]>();

        if (string.IsNullOrWhiteSpace(request.Name))
            errors["Name"] = new[] { "Name must be a non-empty string" };
        if (string.IsNullOrWhiteSpace(request.Email))
            errors["Email"] = new[] { "Email must be a non-empty string" };
        if (string.IsNullOrWhiteSpace(request.Hotline))
            errors["Password"] = new[] { "Hotline must be a non-empty string" };
        if (string.IsNullOrWhiteSpace(request.Website))
            errors["Role"] = new[] { "Website must be a non-empty string" };
        if (string.IsNullOrWhiteSpace(request.Address))
            errors["Role"] = new[] { "Address must be a non-empty string" };

        if (_dbContext.Sellers.Any(s => s.Email == request.Email))
            errors["Email"] = new[] { "Email is already registered" };

        if (errors.Any())
            return BadRequest(new { errors });

        var hotel = new Hotel
        {
            Name = request.Name,
            Email = request.Email,
            Hotline = request.Hotline,
            Website = request.Website,
            Address = request.Address,
        };

        _dbContext.Hotels.Add(hotel);
        _dbContext.SaveChanges();

        return CreatedAtAction(nameof(GetHotel), new { id = hotel.Id }, hotel);
    }

    [HttpGet("{id}")]
    public IActionResult GetHotel(int id)
    {
        var hotel = _dbContext.Sellers.Find(id);
        if (hotel == null)
            return NotFound();

        return Ok(hotel);
    }
    

    }
}