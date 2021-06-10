using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Seminar.DAL;
using Seminar.Web.Models;

namespace Seminar.Web.Controllers
{
    [Authorize(Roles = "Admin")]
    public class UsersController : SeminarController
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        private IQueryable<string> AllRoles => _roleManager.Roles.Select(role => role.Name);

        public UsersController(ILogger<SeminarController> logger, ApplicationDbContext dbContext, UserManager<IdentityUser> userManager, RoleManager<IdentityRole> roleManager) : base(logger, dbContext)
        {
            _userManager = userManager;
            _roleManager = roleManager;
        }

        // GET: Users
        public async Task<IActionResult> Index()
        {
            List<IdentityUser> users = await _dbContext.Users.ToListAsync();

            List<UserViewModel> userViewModels = await users.ConvertToViewModels(_userManager);

            return View(userViewModels);
        }

        // GET: Users/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
                return NotFound();

            IdentityUser user = await _dbContext.Users.FindAsync(id);
            if (user == null)
                return NotFound();

            UserViewModel userViewModel = await user.ConvertToViewModel(_userManager);

            PopulateAll();

            return View(userViewModel);
        }

        // POST: Users/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, UserViewModel userViewModel, string[] roleIds)
        {
            if (id != userViewModel.Id)
                return NotFound();

            if (ModelState.IsValid)
            {
                IdentityUser user = await _userManager.FindByIdAsync(userViewModel.Id);
                IList<string> roles = await _userManager.GetRolesAsync(user);
                userViewModel.Roles = roleIds;
                List<string> toAdd = userViewModel.Roles.Where(role => !roles.Contains(role)).ToList();
                List<string> toRemove = roles.Where(role => !userViewModel.Roles.Contains(role)).ToList();

                IdentityResult result;
                foreach (string role in toAdd)
                {
                    result = await _userManager.AddToRoleAsync(user, role);
                    if (!result.Succeeded)
                        Errors(result);
                }

                foreach (string role in toRemove)
                {
                    result = await _userManager.RemoveFromRoleAsync(user, role);
                    if (!result.Succeeded)
                        Errors(result);
                }

                return RedirectToAction(nameof(Index));
            }

            return await Edit(id);
        }

        // GET: Users/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
                return NotFound();

            IdentityUser user = await _dbContext.Users
                .FirstOrDefaultAsync(m => m.Id == id);
            if (user == null)
                return NotFound();

            UserViewModel userViewModel = await user.ConvertToViewModel(_userManager);
            
            PopulateAll();
            return View(userViewModel);
        }

        // POST: Users/Delete/5
        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            IdentityUser user = await _dbContext.Users.FindAsync(id);
            _dbContext.Users.Remove(user);
            await _dbContext.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        private void PopulateAll()
        {
            ViewBag.AllRoles = AllRoles;
        }

        private void Errors(IdentityResult result)
        {
            foreach (IdentityError error in result.Errors)
                ModelState.AddModelError("", error.Description);
        }
    }
}
