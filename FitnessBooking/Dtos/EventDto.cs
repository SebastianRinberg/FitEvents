using System;

namespace FitnessBooking.Dtos
{
    public class EventDto
    {
        public int Id { get; set; }
        public bool IsCanceled { get; set; }
        public UserDto Instructor { get; set; }
        public DateTime DateTime { get; set; }
        public string Description { get; set; }
        public EventTypeDto EventType { get; set; }
    }
}