using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HotelManagement.Models
{
    public class RatePlan
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set;}

        [Column(TypeName = "varchar(20)")]
        public required string Name { get; set; }

        [Column(TypeName = "DECIMAL(18, 2)")]
        public required decimal Price { get; set; }

        [Column(TypeName = "DATE")]
        public required DateTime Daystart {get; set;}

        [Column(TypeName = "DATE")]
        public required DateTime DayEnd {get; set;}

        [Column(TypeName = "INT")]
        public required string OccupancyLimit {get; set;}

        [Column(TypeName = "INT")]
        public required int Capacity  {get; set;}

        [ForeignKey("Hotel")]
        public int HotelId { get; set;}

        public Hotel? Hotel { get; set; }

    }

}