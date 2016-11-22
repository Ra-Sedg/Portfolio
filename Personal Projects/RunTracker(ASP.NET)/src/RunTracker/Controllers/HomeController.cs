using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using RunTracker.Data;
using RunTracker.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
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
            var chartView = new ChartViewModel();
            chartView.User = GetUser();
            chartView.CurrentDate = DateTime.Today;
            ViewBag.Months = GetMonths();
            ViewBag.Years = GetYears();

            if (id != null && id == 1)
            {
                chartView.Runs = GetUserRuns();
            }
            else
            {
                chartView.Runs = GetFilterRuns(DateTime.Today.Month, DateTime.Today.Year);

            }
            return View(chartView);
        }

        [HttpPost]
        public ActionResult Index(ChartViewModel chartView)
        {
            chartView.User = GetUser();
            ViewBag.Months = GetMonths();
            ViewBag.Years = GetYears();

            if (chartView.ShowAllRuns)
            {
                chartView.Runs = GetUserRuns();
            }
            else
            {
                chartView.Runs = GetFilterRuns(chartView.SelectedMonth, chartView.SelectedYear);
            }
            return View(chartView);
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

        private List<Run> GetFilterRuns(int month, int year)
        {
            List<Run> runs;
            runs = GetUserRuns().Where(r => r.Date.Year == year &&
                                            r.Date.Month == month).ToList();
            return runs;
        }

        private SelectList GetMonths()
        {
            return new SelectList(Enumerable.Range(1, 12).Select(x =>
                       new SelectListItem()
                       {
                           Text = CultureInfo.CurrentCulture.DateTimeFormat.AbbreviatedMonthNames[x - 1],
                           Value = x.ToString()
                       }), "Value", "Text");
        }

        private SelectList GetYears()
        {
            return new SelectList(Enumerable.Range(DateTime.Today.AddYears(-10).Year, 30).Select(x =>
                       new SelectListItem()
                       {
                           Text = x.ToString(),
                           Value = x.ToString()
                       }), "Value", "Text");
        }
    }
}
