using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HotelManagement.Models
{
    public class RatePlanAdditional
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set;}

        [ForeignKey("RatePlan")]
        public int RatePlanId {get; set;}
        public RatePlan? RatePlan {get; set;}

        [ForeignKey("Hotel")]
        public int HotelId { get; set;}

        public Hotel? Hotel { get; set; }
    }
}