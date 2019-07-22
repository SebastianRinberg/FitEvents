using System;
using System.ComponentModel.DataAnnotations;

namespace FitnessBooking.Models
{
    public class Notification
    {
        public int Id { get; private set; }
        public DateTime DateTime { get; private set; }
        public NotificationType Type { get; private set; }
        public DateTime? OriginalDateTime { get; private set; }
        public string OriginalDescription { get; private set; }

        [Required]
        public Event Event { get; private set; }

        //Default constructor som kræves af entity framework
        public Notification()
        {
        }

        //Constructor som modtager 2 argumenter. 
        private Notification(NotificationType type, Event eEvent)
        {
            if (eEvent == null)
            {
                throw new ArgumentNullException("eEvent");
            }

            Type = type;
            Event = eEvent;
            DateTime = DateTime.Now;
        }


        public static Notification EventCreated(Event eEvent)
        {
            return new Notification(NotificationType.EventCreated, eEvent);
        }

        public static Notification EventUpdated(Event newEvent, DateTime originalDateTime, string originalDescription)
        {
            var notification = new Notification(NotificationType.EventUpdated, newEvent);
            notification.OriginalDateTime = originalDateTime;
            notification.OriginalDescription = originalDescription;

            return notification;
        }

        public static Notification EventCanceled(Event eEvent)
        {
            return new Notification(NotificationType.EventCanceled, eEvent);
        }
    }
}