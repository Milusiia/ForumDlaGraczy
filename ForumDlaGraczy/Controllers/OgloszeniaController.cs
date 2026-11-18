using Microsoft.AspNetCore.Mvc;
using ForumDlaGraczy.Models;

namespace ForumDlaGraczy.Controllers
{
    public class OgloszeniaController : Controller
    {
        // Przykładowa lista ogłoszeń
        private static List<OgloszenieModel> ogloszenia = new List<OgloszenieModel>
        {
            new OgloszenieModel
            {
                Id = 1,
                Tytul = "Turniej Counter-Strike 2!",
                Tresc = "W sobotę organizujemy turniej. Zapraszamy wszystkich graczy!"
            },

            new OgloszenieModel
            {
                Id = 2,
                Tytul = "Przerwa techniczna",
                Tresc = "W niedzielę forum będzie niedostępne od godziny 22:00."
            },

            new OgloszenieModel
            {
                Id = 3,
                Tytul = "Nowe podforum",
                Tresc = "Zapraszamy do nowego podforum poświęconego Minecraftowi."
            }
        };

        private static int nastepneId = 4;

        // Wyświetlenie listy ogłoszeń
        [HttpGet]
        public IActionResult Index()
        {
            return View(ogloszenia);
        }

        // Formularz dodawania ogłoszenia
        [HttpGet]
        public IActionResult Dodaj()
        {
            return View();
        }

        // Obsługa dodawania ogłoszenia
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Dodaj(OgloszenieModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            model.Id = nastepneId++;
            ogloszenia.Add(model);

            TempData["Komunikat"] = "Ogłoszenie zostało dodane!";

            return RedirectToAction("Index");
        }

        // Formularz edycji ogłoszenia
        [HttpGet]
        public IActionResult Edytuj(int id)
        {
            var ogloszenie = ogloszenia.FirstOrDefault(o => o.Id == id);

            if (ogloszenie == null)
            {
                return NotFound();
            }

            return View(ogloszenie);
        }

        // Obsługa edycji ogłoszenia
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edytuj(OgloszenieModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var ogloszenie = ogloszenia.FirstOrDefault(o => o.Id == model.Id);

            if (ogloszenie == null)
            {
                return NotFound();
            }

            ogloszenie.Tytul = model.Tytul;
            ogloszenie.Tresc = model.Tresc;

            TempData["Komunikat"] = "Ogłoszenie zostało zmienione!";

            return RedirectToAction("Index");
        }

        // Usuwanie ogłoszenia
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Usun(int id)
        {
            var ogloszenie = ogloszenia.FirstOrDefault(o => o.Id == id);

            if (ogloszenie != null)
            {
                ogloszenia.Remove(ogloszenie);

                TempData["Komunikat"] = "Ogłoszenie zostało usunięte!";
            }

            return RedirectToAction("Index");
        }
    }
}