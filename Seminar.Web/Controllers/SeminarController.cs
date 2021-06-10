using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Seminar.DAL;
using Seminar.Model;

namespace Seminar.Web.Controllers
{
    public abstract class SeminarController : Controller
    {
        protected readonly ILogger<SeminarController> _logger;
        protected ApplicationDbContext _dbContext;

        public SeminarController(ILogger<SeminarController> logger, ApplicationDbContext dbContext)
        {
            _logger = logger;
            _dbContext = dbContext;
        }
    }
}
