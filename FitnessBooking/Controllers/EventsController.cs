using FitnessBooking.Models;
using FitnessBooking.ViewModels;
using Microsoft.AspNet.Identity;
using System;
using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;

namespace FitnessBooking.Controllers
{
    public partial class EventsController : Controller
    {
        private readonly ApplicationDbContext _context;
        public EventsController()
        {
            _context = new ApplicationDbContext();
        }


        [Authorize]
        public ActionResult Mine()
        {
            var userId = User.Identity.GetUserId();
            var events = _context.Events
                .Where(e =>
                    e.InstructorId == userId &&
                    e.DateTime > DateTime.Now &&
                    !e.IsCanceled)
                .Include(e => e.EventType)
                .ToList();

            return View(events);
        }

        [Authorize]
        public ActionResult Attending()
        {
            var userId = User.Identity.GetUserId();
            var events = _context.Attendances
                .Where(a => a.AttendeeId == userId)
                .Select(a => a.Event)
                .Include(e => e.Instructor)
                .Include(e => e.EventType)
                .ToList();

            var viewModel = new EventsViewModel()
            {
                UpcomingEvents = events,
                ShowActions = User.Identity.IsAuthenticated,
                Heading = "Events I'm Attending"
            };
            return View("Events", viewModel);
        }


        [Authorize]
        public ActionResult Create()
        {
            var viewModel = new EventFormViewModel
            {
                EventTypes = _context.EventTypes.ToList(),
                Heading = "Add an Event"

            };
            return View("EventForm", viewModel);
        }

        [Authorize]
        public ActionResult Edit(int id)
        {
            var userId = User.Identity.GetUserId();
            var eEvent = _context.Events.Single(e => e.Id == id && e.InstructorId == userId);
            var viewModel = new EventFormViewModel
            {
                Heading = "Edit Event",
                Id = eEvent.Id,
                EventTypes = _context.EventTypes.ToList(),
                Date = eEvent.DateTime.ToString("d MMM yyyy"),
                Time = eEvent.DateTime.ToString("HH:mm"),
                EventType = eEvent.EventTypeId,
                Description = eEvent.Description
            };
            return View("EventForm", viewModel);
        }

        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(EventFormViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                viewModel.EventTypes = _context.EventTypes.ToList();
                return View("EventForm", viewModel);
            }


            var newEvent = new Event
            {
                InstructorId = User.Identity.GetUserId(),
                DateTime = viewModel.GetDateTime(),
                EventTypeId = viewModel.EventType,
                Description = viewModel.Description
            };
            _context.Events.Add(newEvent);
            _context.SaveChanges();
            return RedirectToAction("Mine", "Events");
        }


        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Update(EventFormViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                viewModel.EventTypes = _context.EventTypes.ToList();
                return View("EventForm", viewModel);
            }

            var UserId = User.Identity.GetUserId();

            var eEvent = _context.Events
                .Include(e => e.Attendances.Select(a => a.Attendee))
                .Single(e => e.Id == viewModel.Id && e.InstructorId == UserId);

            eEvent.Modify(viewModel.GetDateTime(), viewModel.Description, viewModel.EventType);

            _context.SaveChanges();
            return RedirectToAction("Mine", "Events");
        }



    }
}

