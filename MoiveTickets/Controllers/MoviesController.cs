using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MoiveTickets.Data;

namespace MoiveTickets.Controllers
{
    public class MoviesController : Controller
    {
        private readonly AppDbContext _context;

        public MoviesController(AppDbContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index()
        {
            var allMoviess = await _context.Movies.Include(n => n.Cinema).OrderBy(n => n.Title).ToListAsync();
            return View(allMoviess);
        }
    }
}
