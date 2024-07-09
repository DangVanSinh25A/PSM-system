using HotelManagement.Database;
using HotelManagement.Models;
namespace HotelManagement.Repositories
{

    public interface ICancelPolicyRepository
    {
        CancelPolicy CreateCancelPolicy(CancelPolicy cancelPolicy);
    }
    public class CancelPolicyRepository : ICancelPolicyRepository
    {
         private readonly AppDbContext _context;

        public CancelPolicyRepository(AppDbContext context)
        {
            _context = context;
        }
        
        public CancelPolicy CreateCancelPolicy(CancelPolicy cancelPolicy)
        {
            _context.CancelPolicys.Add(cancelPolicy);
            _context.SaveChanges();
            return cancelPolicy;
        }

    }
}