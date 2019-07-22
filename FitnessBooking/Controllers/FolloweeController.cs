using FitnessBooking.Models;
using Microsoft.AspNet.Identity;
using System.Linq;
using System.Web.Mvc;

namespace FitnessBooking.Controllers
{
    public class FolloweeController : Controller
    {
        private ApplicationDbContext _context;

        public FolloweeController()
        {
            _context = new ApplicationDbContext();
        }


        public ActionResult Index()
        {
            var userId = User.Identity.GetUserId();
            var instructors = _context.Followings
                .Where(f => f.FolloweeId == userId)
                .Select(f => f.Followee)
                .ToList();

            return View(instructors);
        }
    }
}