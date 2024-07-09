using HotelManagement.Database;
using HotelManagement.Models;
namespace HotelManagement.Repositories
{

    public interface IAdditionalRepository
    {
        Additional CreateAdditional(Additional additional);
    }
    public class AdditionalRepository : IAdditionalRepository
    {
         private readonly AppDbContext _context;

        public AdditionalRepository(AppDbContext context)
        {
            _context = context;
        }
        
        public Additional CreateAdditional(Additional additional)
        {
            _context.Additionals.Add(additional);
            _context.SaveChanges();
            return additional;
        }

    }
}