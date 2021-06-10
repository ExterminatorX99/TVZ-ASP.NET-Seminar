using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Seminar.DAL;
using Seminar.Model;

namespace Seminar.Web.Controllers
{
    public class HomeController : SeminarController
    {
        public HomeController(ILogger<HomeController> logger, ApplicationDbContext dbContext) : base(logger, dbContext)
        {
        }

        public IActionResult Index() => View();

        public IActionResult Privacy() => View();
    }
}
