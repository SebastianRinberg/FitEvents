using FitnessBooking.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace FitnessBooking.ViewModels
{
    public class EventFormViewModel
    {
        [Required]
        public string Description { get; set; }

        [Required]
        [FutureDate]
        public string Date { get; set; }

        [Required]
        [ValidTime]
        public string Time { get; set; }

        [Required]
        public byte EventType { get; set; }


        public IEnumerable<EventType> EventTypes { get; set; }

        public DateTime GetDateTime()
        {
            return DateTime.Parse(string.Format("{0} {1}", Date, Time));
        }
    }
}