using FitnessBooking.Models;
using FitnessBooking.ViewModels;
using Microsoft.AspNet.Identity;
using System;
using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;

namespace FitnessBooking.Controllers
{
    public class HomeController : Controller
    {
        private ApplicationDbContext _context;
        public HomeController()
        {
            _context = new ApplicationDbContext();
        }


        public ActionResult Index(string query = null)
        {
            var upcomingEvents = _context.Events
                .Include(e => e.Instructor)
                .Include(e => e.EventType)
                .Where(e => e.DateTime > DateTime.Now && !e.IsCanceled);

            if (!string.IsNullOrWhiteSpace(query))
            {
                upcomingEvents = upcomingEvents
                    .Where(e =>
                        e.Instructor.Name.Contains(query) ||
                        e.EventType.Name.Contains(query));
            }

            var userId = User.Identity.GetUserId();
            var attendances = _context.Attendances
                .Where(a => a.AttendeeId == userId && a.Event.DateTime > DateTime.Now)
                .ToList()
                .ToLookup(a => a.EventId);

            var viewModel = new EventsViewModel
            {
                UpcomingEvents = upcomingEvents,
                ShowActions = User.Identity.IsAuthenticated,
                Heading = "Upcoming Events",
                SearchTerm = query,
                Attendances = attendances
            };

            return View("Events", viewModel);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}