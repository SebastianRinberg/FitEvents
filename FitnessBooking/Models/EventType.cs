using System.ComponentModel.DataAnnotations;

namespace FitnessBooking.Models
{
    public class EventType
    {
        public byte Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }
    }
}