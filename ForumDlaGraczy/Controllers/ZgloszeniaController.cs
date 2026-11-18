using Microsoft.AspNetCore.Mvc;
using ForumDlaGraczy.Models;

namespace ForumDlaGraczy.Controllers
{
    public class ZgloszeniaController : Controller
    {
        // Przykładowe zgłoszenia
        private static List<ZgloszenieModel> zgloszenia = new List<ZgloszenieModel>
        {
            new ZgloszenieModel
            {
                Id = 1,
                WiadomoscId = 15,
                AutorZglaszajacy = "Gracz123",
                AutorWiadomosci = "GamingMaster",
                TrescWiadomosci = "Przykładowa obraźliwa wiadomość.",
                Powod = "Obraźliwa treść",
                Status = "Oczekujące"
            },

            new ZgloszenieModel
            {
                Id = 2,
                WiadomoscId = 20,
                AutorZglaszajacy = "ProPlayer",
                AutorWiadomosci = "Gracz456",
                TrescWiadomosci = "Przykładowa wiadomość reklamowa.",
                Powod = "Spam",
                Status = "Oczekujące"
            }
        };

        // Wyświetlenie listy zgłoszeń
        [HttpGet]
        public IActionResult Index()
        {
            return View(zgloszenia);
        }

        // Oznaczenie zgłoszenia jako rozpatrzone
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Rozpatrz(int id)
        {
            var zgloszenie = zgloszenia.FirstOrDefault(z => z.Id == id);

            if (zgloszenie != null)
            {
                zgloszenie.Status = "Rozpatrzone";
            }

            return RedirectToAction("Index");
        }
    }
}