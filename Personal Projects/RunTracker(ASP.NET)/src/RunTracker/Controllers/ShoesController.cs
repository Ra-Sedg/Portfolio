using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
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
    public class ShoesController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _manager;

        public ShoesController(UserManager<ApplicationUser> manager, ApplicationDbContext context)
        {
            _manager = manager;
            _context = context;
        }

        // GET: Shoes
        public ActionResult Index(string sortOrder)
        {
            ViewBag.NameSort = sortOrder == "Name_Desc" ? "Name_Asc" : "Name_Desc";
            ViewBag.MileageSort = sortOrder == "Mileage_Desc" ? "Mileage_Asc" : "Mileage_Desc";

            var Shoes = GetUserShoes();
            Shoes = Sort.SortShoes(Shoes, sortOrder);

            return View(Shoes);
        }

        // GET: Shoes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var shoe = await _context.Shoe
                       .Include(s => s.Runs)
                       .SingleOrDefaultAsync(m => m.Id == id);

            if (shoe == null)
            {
                return NotFound();
            }

            return View(shoe);
        }

        // GET: Shoes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Shoes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,ApplicationUserId,InUse,Name")] Shoe shoe)
        {
            if (ModelState.IsValid)
            {
                shoe.InUse = true;
                shoe.ApplicationUserId = GetUserId();
                _context.Add(shoe);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(shoe);
        }

        // GET: Shoes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var shoe = await _context.Shoe.SingleOrDefaultAsync(m => m.Id == id);
            if (shoe == null)
            {
                return NotFound();
            }

            return View(shoe);
        }

        // POST: Shoes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,ApplicationUserId,InUse,Name")] Shoe shoe)
        {
            if (id != shoe.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    shoe.ApplicationUserId = GetUserId();
                    _context.Update(shoe);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ShoeExists(shoe.Id))
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
            return View(shoe);
        }

        // GET: Shoes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var shoe = await _context.Shoe
                      .Include(s => s.Runs)
                      .SingleOrDefaultAsync(m => m.Id == id);


            if (shoe == null)
            {
                return NotFound();
            }

            return View(shoe);
        }

        // POST: Shoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            //var shoe = await _context.Shoe.SingleOrDefaultAsync(m => m.Id == id);
            var shoe = await _context.Shoe
                      .Include(s => s.Runs)
                      .SingleOrDefaultAsync(m => m.Id == id);
            foreach (Run r in shoe.Runs)
            {
                r.ShoeId = null;
            }

            _context.Shoe.Remove(shoe);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        private bool ShoeExists(int id)
        {
            return _context.Shoe.Any(e => e.Id == id);
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
    }
}
