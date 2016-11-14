using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RunTracker.Data;
using Microsoft.AspNetCore.Identity;
using RunTracker.Models;
using RunTracker.Helpers;
using Microsoft.AspNetCore.Mvc.Rendering;

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
            var Runs = GetUserRuns();
            var Today = DateTime.UtcNow;



            switch (id)
            {
                case 0:
                    Runs = Runs
                        .Where(r => r.Date.Year == Today.Year &&
                                    r.Date.Month == Today.Month).ToList();
                    break;
                case 1:
                    var StartDate = Today.AddMonths(-3);
                    Runs = Runs
                        .Where(r => r.Date >= StartDate &&
                                    r.Date <= Today).ToList();
                    break;
                case 2:
                    break;
                default:
                    break;

            }
            return View(Runs.OrderBy(r => r.Date));
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

        public IActionResult GraphRuns()
        {
            return View();
        }


        // GET: Runs/GraphRun
        [HttpPost]
        public IActionResult GraphRuns(int? id)
        {
            var Runs = GetUserRuns();
            var Today = DateTime.UtcNow;


            
            switch (id)
            {
                case 0:

                    Runs = Runs
                        .Where(r => r.Date.Year == Today.Year &&
                                    r.Date.Month == Today.Month).ToList();
                    break;
                case 1:
                    var StartDate = Today.AddMonths(-3);
                    Runs = Runs
                        .Where(r => r.Date >= StartDate &&
                                    r.Date <= Today).ToList();
                    break;
                case 2:
                    break;
                default:
                    break;

            }
            return View(Runs);
        }



        private string GetUserId()
        {
            return _manager.GetUserId(HttpContext.User);
        }

        private List<Run> GetUserRuns()
        {
            return _context.Run
                   .Where(run => run.ApplicationUserId == GetUserId())
                   .ToList();
        }

        
        
    }
}
