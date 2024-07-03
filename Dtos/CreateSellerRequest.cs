namespace HotelManagement.Dtos
{
    public class CreateSellerRequest
    {
        public required string Name { get; set; }
        public required string Email { get; set; }
        public required string Password { get; set; }
        public required string Role { get; set; }
        public required int  Permission { get; set; }
        public required int HotelId { get; set; }
    }
}