using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Seminar.DAL;
using Seminar.Model;

namespace Seminar.Web.Controllers
{
    public class CitiesController : SeminarController
    {
        public CitiesController(ILogger<SeminarController> logger, ApplicationDbContext dbContext) : base(logger, dbContext)
        {
        }

        // GET: Cities
        public async Task<IActionResult> Index() => View(await _dbContext.Cities.ToListAsync());

        // GET: Cities/Details/5
        [Route("[controller]/Detalji")]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
                return NotFound();

            City city = await _dbContext.Cities
                .FirstOrDefaultAsync(m => m.ID == id);
            if (city == null)
                return NotFound();

            return View(city);
        }

        // GET: Cities/Create
        public IActionResult Create() => View();

        // POST: Cities/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Name")] City city)
        {
            if (ModelState.IsValid)
            {
                _dbContext.Add(city);
                await _dbContext.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            return View(city);
        }

        // GET: Cities/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
                return NotFound();

            City city = await _dbContext.Cities.FindAsync(id);
            if (city == null)
                return NotFound();
            return View(city);
        }

        // POST: Cities/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, City city)
        {
            if (id != city.ID)
                return NotFound();

            if (ModelState.IsValid)
            {
                try
                {
                    _dbContext.Update(city);
                    await _dbContext.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CityExists(city.ID))
                        return NotFound();
                    throw;
                }

                return RedirectToAction(nameof(Index));
            }

            return View(city);
        }

        // GET: Cities/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
                return NotFound();

            City city = await _dbContext.Cities
                .FirstOrDefaultAsync(m => m.ID == id);
            if (city == null)
                return NotFound();

            return View(city);
        }

        // POST: Cities/Delete/5
        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            City city = await _dbContext.Cities.FindAsync(id);
            _dbContext.Cities.Remove(city);
            await _dbContext.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CityExists(int id)
        {
            return _dbContext.Cities.Any(e => e.ID == id);
        }
    }
}
