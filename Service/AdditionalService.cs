using HotelManagement.Models;
using HotelManagement.Repositories;
namespace HotelManagement.Sevice
{
         public interface IAdditionalService
        {
            Additional CreateAdditional(Additional additional);
        }

        public class AdditionalService : IAdditionalService
        {
            private readonly IAdditionalRepository _additionalRepository;

            public AdditionalService(IAdditionalRepository additionalRepository)
            {
                _additionalRepository =  additionalRepository;
            }

            public Additional CreateAdditional(Additional additional)
            {
                return _additionalRepository.CreateAdditional(additional);
            }
    }
}