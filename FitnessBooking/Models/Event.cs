using System;
using System.ComponentModel.DataAnnotations;

namespace FitnessBooking.Models
{
    public class Event
    {
        public int Id { get; set; }


        public ApplicationUser Instructor { get; set; }

        [Required]
        public string InstructorId { get; set; }

        public DateTime DateTime { get; set; }

        [Required]
        [StringLength(250)]
        public string Description { get; set; }

        public EventType EventType { get; set; }

        [Required]
        public byte EventTypeId { get; set; }

    }
}