using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ForumDlaGraczy.Data;
using ForumDlaGraczy.Models;

namespace ForumDlaGraczy.Controllers
{
    public class StatystykiController : Controller
    {
        private readonly ApplicationDbContext _context;

        public StatystykiController(ApplicationDbContext context)
        {
            _context = context;
        }

        // Wyświetlenie statystyk forum
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var model = new StatystykiForumModel
            {
                LiczbaUzytkownikow = await _context.Users.CountAsync(),

                LiczbaWatkow = await _context.Topics.CountAsync(),

                LiczbaOdpowiedzi = await _context.Posts.CountAsync(),

                LiczbaKategorii = await _context.Kategorie.CountAsync(),

                LiczbaPodforow = await _context.Podfora.CountAsync(),

                LiczbaOdslon = await _context.Topics
                    .SumAsync(w => (int?)w.LiczbaOdslon) ?? 0
            };

            return View(model);
        }
    }
}