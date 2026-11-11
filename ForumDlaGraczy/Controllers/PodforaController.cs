using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using ForumDlaGraczy.Models;

namespace ForumDlaGraczy.Controllers
{
    public class PodforaController : Controller
    {
        private List<SelectListItem> PobierzKategorie()
        {
            return new List<SelectListItem>
            {
                new SelectListItem { Value = "1", Text = "Gry komputerowe" },
                new SelectListItem { Value = "2", Text = "Gry multiplayer" },
                new SelectListItem { Value = "3", Text = "Sprzęt gamingowy" },
                new SelectListItem { Value = "4", Text = "Konsole" }
            };
        }

        // formularz dodawania podforum
        [HttpGet]
        public IActionResult Dodaj()
        {
            ViewBag.Kategorie = PobierzKategorie();

            return View();
        }

        // Obsługa formularza dodawania podforum
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Dodaj(PodforumModel model)
        {
            ViewBag.Kategorie = PobierzKategorie();

            if (!ModelState.IsValid)
            {
                return View(model);
            }

            ViewBag.Komunikat = "Dane podforum są poprawne!";

            return View(model);
        }

        // formularz edycji podforum
        [HttpGet]
        public IActionResult Edytuj()
        {
            ViewBag.Kategorie = PobierzKategorie();

            var podforum = new PodforumModel
            {
                Id = 1,
                Nazwa = "TEST",
                Opis = "test test",
                KategoriaForumId = 2
            };

            return View(podforum);
        }

        // Obsługa formularza edycji podforum
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edytuj(PodforumModel model)
        {
            ViewBag.Kategorie = PobierzKategorie();

            if (!ModelState.IsValid)
            {
                return View(model);
            }

            ViewBag.Komunikat = "Dane podforum zostały poprawnie zmienione!";

            return View(model);
        }
    }
}