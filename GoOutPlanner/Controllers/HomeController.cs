using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using GoOutPlanner.Models;

namespace GoOutPlanner.Controllers
{
    public class HomeController : Controller
    {
        private readonly AppDbContext _context;

        public HomeController(AppDbContext context)
        {
            _context = context;
        }

        // READ ALL
        public async Task<IActionResult> Index()
        {
            var places = await _context.Places.ToListAsync();
            return View(places);
        }

        // CREATE GET
        public IActionResult Create()
        {
            return View();
        }

        // CREATE POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Place place)
        {
            if (ModelState.IsValid)
            {
                _context.Add(place);
                await _context.SaveChangesAsync();

                return RedirectToAction(nameof(Index));
            }

            return View(place);
        }

        // EDIT GET
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
                return NotFound();

            var place = await _context.Places.FindAsync(id);

            if (place == null)
                return NotFound();

            return View(place);
        }

        // EDIT POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Place place)
        {
            if (id != place.Id)
                return NotFound();

            if (ModelState.IsValid)
            {
                _context.Update(place);
                await _context.SaveChangesAsync();

                return RedirectToAction(nameof(Index));
            }

            return View(place);
        }

        // DELETE GET
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
                return NotFound();

            var place = await _context.Places
                .FirstOrDefaultAsync(x => x.Id == id);

            if (place == null)
                return NotFound();

            return View(place);
        }

        // DELETE POST
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var place = await _context.Places.FindAsync(id);

            if (place != null)
            {
                _context.Places.Remove(place);
                await _context.SaveChangesAsync();
            }

            return RedirectToAction(nameof(Index));
        }

        // DETAILS
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
                return NotFound();

            var place = await _context.Places
                .FirstOrDefaultAsync(x => x.Id == id);

            if (place == null)
                return NotFound();

            return View(place);
        }
    }
}