using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebFrontToBack.DAL;

namespace WebFrontToBack.Controllers
{
    public class ServicesController : Controller
    {
        private readonly AppDbContext _context;

        public ServicesController(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _context.Services
                .Include(s => s.ServiceImages)
                .OrderByDescending(s => s.Id)
                .Where(s => !s.IsDeleted)
                .ToListAsync()
                );
        }
    }
}
