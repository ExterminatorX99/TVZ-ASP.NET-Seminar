using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Seminar.DAL;
using Seminar.Model;
using Seminar.Web.Models;

namespace Seminar.Web.Controllers
{
    public class WritersController : SeminarController
    {
        public WritersController(ILogger<WritersController> logger, ApplicationDbContext dbContext) : base(logger, dbContext)
        {
        }

        public IActionResult Index(WriterFilterModel filter)
        {
            IQueryable<Writer> writerQuery = _dbContext.Writers.IncludeAll();

            //if (!string.IsNullOrWhiteSpace(filter.FullName))
            //    writerQuery = writerQuery.Where(w => (w.FirstName + " " + w.LastName).Contains(filter.FullName, StringComparison.OrdinalIgnoreCase));
            ////if (filter.Gender)
            //writerQuery = writerQuery.Where(w => w.Gender == filter.Gender);
            //if (!string.IsNullOrWhiteSpace(filter.Email))
            //    writerQuery = writerQuery.Where(w => w.Email.Contains(filter.Email, StringComparison.OrdinalIgnoreCase));
            //if (!string.IsNullOrWhiteSpace(filter.PhoneNumber))
            //    writerQuery = writerQuery.Where(w => w.PhoneNumber.Contains(filter.PhoneNumber, StringComparison.OrdinalIgnoreCase));
            //if (!string.IsNullOrWhiteSpace(filter.CityName))
            //    writerQuery = writerQuery.Where(w => w.City.Name.Contains(filter.CityName, StringComparison.OrdinalIgnoreCase));

            return View(writerQuery.ToList());
        }

        public IActionResult Details(int id)
        {
            Writer writer = _dbContext.Writers.IncludeAll().SingleOrDefault(w => w.ID == id);

            if (writer == null)
                return NotFound();

            return View(writer);
        }

        [HttpGet]
        public IActionResult Create()
        {
            PopulateAll();
            return View();
        }

        [HttpPost]
        [ActionName("Create")]
        public async Task<IActionResult> CreatePost(Writer writer)
        {
            if (ModelState.IsValid)
            {
                _dbContext.Add(writer);
                await _dbContext.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            PopulateAll();
            return View(writer);
        }

        [HttpGet]
        public IActionResult Edit(int? id)
        {
            if (id == null)
                return NotFound();

            Writer writer = _dbContext.Writers.IncludeAll().SingleOrDefault(w => w.ID == id);

            if (writer == null)
                return NotFound();

            PopulateAll(writer.CityID);
            return View(writer);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int? id, Writer writer)
        {
            if (id != writer.ID)
                return NotFound();

            if (ModelState.IsValid)
            {
                try
                {
                    _dbContext.Update(writer);
                    await _dbContext.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!WriterExists(writer.ID))
                        return NotFound();
                    throw;
                }

                return RedirectToAction(nameof(Index));
            }

            PopulateAll(writer.CityID);
            return View(writer);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
                return NotFound();

            Writer writer = await _dbContext.Writers
                .FirstOrDefaultAsync(m => m.ID == id);
            if (writer == null)
                return NotFound();

            return View(writer);
        }

        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            Writer writer = await _dbContext.Writers.FindAsync(id);
            _dbContext.Writers.Remove(writer);
            await _dbContext.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool WriterExists(int id)
        {
            return _dbContext.Writers.Any(e => e.ID == id);
        }

        private void PopulateAll(int? cityID = null)
        {
            IQueryable<City> citiesQuery = _dbContext.Cities;

            ViewBag.CityID = new SelectList(citiesQuery.AsNoTracking(), "ID", "Name", cityID);
        }
    }
}
