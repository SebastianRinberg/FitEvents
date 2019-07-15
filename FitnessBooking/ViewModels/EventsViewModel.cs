using FitnessBooking.Models;
using System.Collections.Generic;

namespace FitnessBooking.ViewModels
{
    public class EventsViewModel
    {
        public IEnumerable<Event> UpcomingEvents { get; set; }
        public bool ShowActions { get; set; }
        public string Heading { get; set; }
    }
}