using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace FitnessBooking.Models
{
    //Model som repræsenterer et event. 
    //Navigation properties linker de forskellige models sammen.
    //Overskriver entity framework conventions med data annotations  
    public class Event
    {
        public int Id { get; set; }

        public bool IsCanceled { get; private set; }

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

        public ICollection<Attendance> Attendances { get; private set; }


        //Constructors
        public Event()
        {
            Attendances = new Collection<Attendance>();
        }


        //Methods
        public void Cancel()
        {
            IsCanceled = true;

            var notification = Notification.EventCanceled(this);

            foreach (var attendee in Attendances.Select(a => a.Attendee))
            {
                attendee.Notify(notification);
            }
        }

        public void Modify(DateTime dateTime, string description, byte eventType)
        {
            var notification = Notification.EventUpdated(this, DateTime, Description);

            DateTime = dateTime;
            Description = description;
            EventTypeId = eventType;

            foreach (var attendee in Attendances.Select(a => a.Attendee))
            {
                attendee.Notify(notification);
            }
        }
    }
}