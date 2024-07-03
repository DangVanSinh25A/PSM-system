using HotelManagement.Database;
using Microsoft.AspNetCore.Mvc;
using HotelManagement.Models;
using Microsoft.EntityFrameworkCore;
using HotelManagement.Dtos;
namespace HotelManagement.Controllers{

[ApiController]
[Route("api/seller")]
public class SellerController : ControllerBase
{
    private readonly AppDbContext _dbContext;

    public SellerController(AppDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    [HttpPost]
    public IActionResult CreateSeller(CreateSellerRequest request)
    {
        var errors = new Dictionary<string, string[]>();

        if (string.IsNullOrWhiteSpace(request.Name))
            errors["Name"] = new[] { "Name must be a non-empty string" };
        if (string.IsNullOrWhiteSpace(request.Email))
            errors["Email"] = new[] { "Email must be a non-empty string" };
        if (string.IsNullOrWhiteSpace(request.Password))
            errors["Password"] = new[] { "Password must be a non-empty string" };
        if (string.IsNullOrWhiteSpace(request.Role))
            errors["Role"] = new[] { "Role must be a non-empty string" };
        // if (request.Permission == null)
        //     errors["Permissions"] = new[] { "Permissions must be a list of non-empty strings" };
        if (request.HotelId < 0)
            errors["HotelId"] = new[] { "Hotel ID must be a positive integer" };

        if (_dbContext.Sellers.Any(s => s.Email == request.Email))
            errors["Email"] = new[] { "Email is already registered" };

        if (errors.Any())
            return BadRequest(new { errors });

        var seller = new Seller
        {
            Name = request.Name,
            Email = request.Email,
            Password = request.Password,
            Role = request.Role,
            Permission = request.Permission,
            HotelId = request.HotelId,
        };

        _dbContext.Sellers.Add(seller);
        _dbContext.SaveChanges();

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