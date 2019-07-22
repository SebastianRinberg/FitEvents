using FitnessBooking.Models;
using Microsoft.AspNet.Identity;
using System.Data.Entity;
using System.Linq;
using System.Web.Http;

namespace FitnessBooking.Controllers.Api
{

    [Authorize]
    public class EventsController : ApiController
    {
        private ApplicationDbContext _context;

        public EventsController()
        {
            _context = new ApplicationDbContext();
        }

        [HttpDelete]
        public IHttpActionResult Cancel(int id)
        {
            var userId = User.Identity.GetUserId();
            var eEvent = _context.Events
                .Include(e => e.Attendances.Select(a => a.Attendee))
                .Single(e => e.Id == id && e.InstructorId == userId);


            if (eEvent.IsCanceled)
            {
                return NotFound();
            }

            eEvent.Cancel();

            _context.SaveChanges();
            return Ok();
        }
    }
}