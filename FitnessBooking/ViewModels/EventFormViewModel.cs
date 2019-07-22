using FitnessBooking.Controllers;
using FitnessBooking.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;
using System.Web.Mvc;

namespace FitnessBooking.ViewModels
{
    public class EventFormViewModel
    {
        public int Id { get; set; }
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

        public string Heading { get; set; }

        public string Action
        {
            get
            {
                Expression<Func<EventsController, ActionResult>> update = (c => c.Update(this));
                Expression<Func<EventsController, ActionResult>> create = (c => c.Create(this));

                var action = (Id != 0) ? update : create;
                return (action.Body as MethodCallExpression).Method.Name;
            }
        }

        public DateTime GetDateTime()
        {
            return DateTime.Parse(string.Format("{0} {1}", Date, Time));
        }
    }
}