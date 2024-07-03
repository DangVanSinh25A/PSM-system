namespace HotelManagement.Dtos
{
    public class CreateHotelRequest
    {
        public required string Name { get; set; }
        public required string Email { get; set; }
        public required string Hotline { get; set; }
        public required string Website { get; set; }
        public required string  Address { get; set; }
    }
}