using System.ComponentModel.DataAnnotations;
namespace HotelManagement.Dtos
{
    public class CreatePaymentConstraintRequest
    {
        [Required(ErrorMessage = "Name must be provided")]
        public required string Name { get; set; }

        [Required(ErrorMessage = "Description must be provided")]
        public required string Description { get; set; }
    }
}