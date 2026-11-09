using Microsoft.AspNetCore.Mvc;
using ForumDlaGraczy.Models;

namespace ForumDlaGraczy.Controllers
{
    public class OgloszeniaController : Controller
    {
        // formularz dodawania ogłoszenia
        [HttpGet]
        public IActionResult Dodaj()
        {
            return View();
        }

        // Obsługa formularza dodawania ogłoszenia
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Dodaj(OgloszenieModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            ViewBag.Komunikat = "Ogłoszenie zostało poprawnie przygotowane!";

            return View(model);
        }

        // formularz edycji ogłoszenia
        [HttpGet]
        public IActionResult Edytuj()
        {
            var ogloszenie = new OgloszenieModel
            {
                Id = 1,
                Tytul = "Turniej Gry",
                Tresc = "Test test"
            };

            return View(ogloszenie);
        }

        // Obsługa formularza edycji ogłoszenia
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edytuj(OgloszenieModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            ViewBag.Komunikat = "Ogłoszenie zostało poprawnie zmienione!";

            return View(model);
        }
    }
}