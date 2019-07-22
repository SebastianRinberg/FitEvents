using System;
using FitnessBooking.Models;

namespace FitnessBooking.Dtos
{
    public class NotificationDto
    {
        public DateTime DateTime { get; set; }
        public NotificationType Type { get; set; }
        public DateTime? OriginalDateTime { get; set; }
        public string OriginalDescription { get; set; }
        public EventDto Event { get; set; }
    }
}