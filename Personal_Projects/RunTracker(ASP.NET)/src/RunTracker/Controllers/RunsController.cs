using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using RunTracker.Data;
using RunTracker.Helpers;
using RunTracker.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RunTracker.Controllers
{
    [Authorize]
    public class RunsController : Controller
    {
        private readonly UserManager<ApplicationUser> _manager;
        private readonly ApplicationDbContext _context;

        public RunsController(UserManager<ApplicationUser> manager, ApplicationDbContext context)
        {
            _manager = manager;
            _context = context;
        }

        // GET: Runs
        public IActionResult Index(string sortOrder)
        {
            // Set up sorting parameters.
            ViewBag.LocationSort = sortOrder == "Location_Asc" ? "Location_Desc" : "Location_Asc";
            ViewBag.DateSort = sortOrder == "Date_Asc" ? "Date_Desc" : "Date_Asc";
            ViewBag.DistanceSort = sortOrder == "Distance_Asc" ? "Distance_Desc" : "Distance_Asc";
            ViewBag.PaceSort = sortOrder == "Pace_Asc" ? "Pace_Desc" : "Pace_Asc";
            ViewBag.ShoeSort = sortOrder == "Shoe_Asc" ? "Shoe_Desc" : "Shoe_Asc";

            // Get user shoe names.
            foreach (Shoe s in GetUserShoes())
            {
                ViewData[s.Id.ToString()] = s.Name;
            }

            var runs = GetUserRuns();
            runs = Sort.SortRuns(runs, sortOrder);

            return View(runs);
        }

        // GET: Runs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var run = await _context.Run.SingleOrDefaultAsync(m => m.Id == id);

            if (run == null)
            {
                return NotFound();
            }

            var shoe = _context.Shoe.SingleOrDefault(s => s.Id == run.ShoeId);
            ViewData["ShoeName"] = shoe.Name;

            return View(run);
        }

        // GET: Runs/Create
        public IActionResult Create()
        {
            var shoes = GetUserShoes();
            ViewBag.Shoes = new SelectList(shoes, "Id", "Name");
            ViewBag.Date = System.DateTime.Today.Date;
            return View();
        }

        // POST: Runs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,ApplicationUserId,Date,Distance,Hours,Location,Minutes,Seconds,ShoeId")] Run run)
        {
            if (ModelState.IsValid)
            {
                run.ApplicationUserId = GetUserId();
                _context.Add(run);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(run);
        }

        // GET: Runs/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var run = await _context.Run.SingleOrDefaultAsync(m => m.Id == id);
            ViewBag.Shoes = new SelectList(GetUserShoes(), "Id", "Name");

            if (run == null)
            {
                return NotFound();
            }
            return View(run);
        }

        // POST: Runs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,ApplicationUserId,Date,Distance,Hours,Location,Minutes,Seconds,ShoeId")] Run run)
        {
            if (id != run.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    run.ApplicationUserId = GetUserId();
                    _context.Update(run);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RunExists(run.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction("Index");
            }
            return View(run);
        }

        // GET: Runs/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var run = await _context.Run.SingleOrDefaultAsync(m => m.Id == id);

            if (run == null)
            {
                return NotFound();
            }

            var shoe = _context.Shoe.SingleOrDefault(s => s.Id == run.ShoeId);

            if (shoe == null)
            {
                ViewData["ShoeName"] = "N/A";
            }
            else
            {
                ViewData["ShoeName"] = shoe.Name;
            }

            return View(run);
        }

        // POST: Runs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var run = await _context.Run.SingleOrDefaultAsync(m => m.Id == id);
            _context.Run.Remove(run);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        // Helpers
        private bool RunExists(int id)
        {
            return _context.Run.Any(e => e.Id == id);
        }

        private string GetUserId()
        {
            return _manager.GetUserId(HttpContext.User);
        }

        private List<Shoe> GetUserShoes()
        {
            return _context.Shoe
                   .Where(shoe => shoe.ApplicationUserId == GetUserId())
                   .Include(shoe => shoe.Runs)
                   .ToList();
        }

        private List<Run> GetUserRuns()
        {
            return _context.Run
                   .Where(run => run.ApplicationUserId == GetUserId())
                   .ToList();
        }
    }
}
