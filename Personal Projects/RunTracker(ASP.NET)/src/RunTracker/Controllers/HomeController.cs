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
            ViewBag.Months = GetMonths(GetUserRuns());
            ViewBag.Years = GetYears(GetUserRuns());

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
            ViewBag.Months = GetMonths(GetUserRuns());
            ViewBag.Years = GetYears(GetUserRuns());

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

        private SelectList GetMonths(List<Run> runs)
        {
            // Select Months for which run data exists.
            List<int> runMonths = new List<int>();
            runMonths = runs.Select(r => r.Date.Month).Distinct().OrderByDescending(m => m).ToList();

            // Populate and return selectList with abbriviated month names for all months in runMonths.
            return new SelectList(runMonths.Select(x =>
                       new SelectListItem()
                       {
                           Text = CultureInfo.CurrentCulture.DateTimeFormat.AbbreviatedMonthNames[x - 1],
                           Value = x.ToString()
                       }), "Value", "Text");
        }

        private SelectList GetYears(List<Run> runs)
        {
            // Select years for which run data exists.
            List<int> runYears = new List<int>();
            runYears = runs.Select(r => r.Date.Year).Distinct().OrderByDescending(y => y).ToList();

            // Populate and return selectList for all years in runYears.
            return new SelectList(runYears.Select(x =>
                       new SelectListItem()
                       {
                           Text = x.ToString(),
                           Value = x.ToString()
                       }), "Value", "Text");
        }
    }
}
