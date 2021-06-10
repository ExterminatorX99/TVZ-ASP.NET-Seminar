using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Seminar.DAL;
using Seminar.Model;

namespace Seminar.Web.Controllers
{
    public class ArticlesController : SeminarController
    {
        public ArticlesController(ILogger<WritersController> logger, ApplicationDbContext dbContext) : base(logger, dbContext)
        {
        }

        public IActionResult Index()
        {
            IQueryable<Article> articleQuery = _dbContext.Articles.IncludeAll();

            return View(articleQuery.ToList());
        }

        public async Task<IActionResult> View(int? id)
        {
            if (id == null)
                return NotFound();

            Article article = await _dbContext.Articles
                .IncludeAll()
                .SingleOrDefaultAsync(m => m.ID == id);
            if (article == null)
                return NotFound();

            return View(article);
        }

        public IActionResult Details(int? id)
        {
            if (id == null)
                return NotFound();

            Article article = _dbContext.Articles.IncludeAll().SingleOrDefault(a => a.ID == id);

            if (article == null)
                return NotFound();

            return View(article);
        }

        [HttpGet]
        public IActionResult Create()
        {
            PopulateAll();
            return View();
        }

        [HttpPost]
        [ActionName("Create")]
        public async Task<IActionResult> CreatePost(Article article)
        {
            if (ModelState.IsValid)
            {
                article.PublishDateTime = DateTime.UtcNow;
                _dbContext.Add(article);
                await _dbContext.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            return View(article);
        }

        [HttpGet]
        public IActionResult Edit(int? id)
        {
            if (id == null)
                return NotFound();

            Article article = _dbContext.Articles.IncludeAll().SingleOrDefault(a => a.ID == id);

            if (article == null)
                return NotFound();

            PopulateAll(article.WriterID, article.CategoryID);
            return View(article);
        }

        [HttpPost]
        [ActionName("Edit")]
        public async Task<IActionResult> EditPost(int? id)
        {
            if (id == null)
                return BadRequest();

            Article article = await _dbContext.Articles.IncludeAll().SingleOrDefaultAsync(a => a.ID == id);
            if (await TryUpdateModelAsync(article))
            {
                await _dbContext.SaveChangesAsync();

                return RedirectToAction(nameof(Edit));
            }

            return View(article);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
                return NotFound();

            Article article = await _dbContext.Articles
                .FirstOrDefaultAsync(m => m.ID == id);
            if (article == null)
                return NotFound();

            return View(article);
        }

        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            Article article = await _dbContext.Articles.FindAsync(id);
            _dbContext.Articles.Remove(article);
            await _dbContext.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private void PopulateAll(int? writerID = null, int? categoryID = null)
        {
            IQueryable<Writer> departmentsQuery = _dbContext.Writers;
            IQueryable<Category> categoriesQuery = _dbContext.Categories;

            ViewBag.WriterID = new SelectList(departmentsQuery.AsNoTracking(), "ID", "FullName", writerID);
            ViewBag.CategoryID = new SelectList(categoriesQuery.AsNoTracking(), "ID", "Name", categoryID);
            ViewBag.HeaderImageID = null;
        }
    }
}
