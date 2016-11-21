using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using RunTracker.Data;
using RunTracker.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace RunTracker.Controllers
{
    public class HomeController : Controller
    {
        private readonly UserManager<ApplicationUser> _manager;
        private readonly ApplicationDbContext _context;

        public HomeController(UserManager<ApplicationUser> manager, ApplicationDbContext context)
        {
            _manager = manager;
            _context = context;
        }

        public IActionResult Index(int? id)
        {
            var user = GetUser();
            var runs = GetFilterRuns(id);
            ViewBag.Name = user.GetName();

            if (runs.Any())
            {
                ViewBag.Mileage = "Total Mileage: " + user.GetTotalMileage() + " Miles";
                ViewBag.Fastest = "Fastest Run: " + user.GetFastest();
                ViewBag.Farthest = "Farthest Run: " + user.GetFarthest();
            }
            else
            {
                ViewBag.NoRunsMsg = "No runs logged, get out there!";
            }

            return View(runs.OrderBy(r => r.Date));
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Robert Adam Sedgwick - Developer";

            return View();
        }

        public IActionResult Error()
        {
            return View();
        }

        // Helpers
        private string GetUserId()
        {
            return _manager.GetUserId(HttpContext.User);
        }

        private ApplicationUser GetUser()
        {
            return _context.ApplicationUser
                    .Where(user => user.Id == GetUserId())
                    .FirstOrDefault();
        }

        private List<Run> GetUserRuns()
        {
            return _context.Run
                   .OrderBy(r => r.Date)
                   .Where(run => run.ApplicationUserId == GetUserId())
                   .ToList();
        }

        private List<Run> GetFilterRuns(int? rangeIndication)
        {
            List<Run> run;
            var Today = DateTime.UtcNow;

            // Filter runs 
            switch (rangeIndication)
            {
                // Current month
                case 0:
                    run = GetUserRuns()
                           .Where(r => r.Date.Year == Today.Year &&
                                       r.Date.Month == Today.Month).ToList();
                    break;
                // Past 3 months
                case 1:
                    var StartDate = Today.AddMonths(-3);
                    run = GetUserRuns()
                           .Where(r => r.Date >= StartDate &&
                                       r.Date <= Today).ToList();
                    break;
                // All time
                case 2:
                    run = GetUserRuns();
                    break;
                // This month
                default:
                    run = GetUserRuns()
                        .Where(r => r.Date.Year == Today.Year &&
                                    r.Date.Month == Today.Month).ToList();
                    break;
            }

            return run;
        }
    }
}
