using Microsoft.AspNetCore.Mvc;
using ForumDlaGraczy.Models;

namespace ForumDlaGraczy.Controllers
{
    public class KategorieController : Controller
    {
        // formularz dodawania kategorii
        [HttpGet]
        public IActionResult Dodaj()
        {
            return View();
        }

        // Obsługa formularza dodawania kategorii
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Dodaj(KategoriaForumModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            ViewBag.Komunikat = "Dane kategorii są poprawne!";

            return View(model);
        }

        // formularz edycji kategorii
        [HttpGet]
        public IActionResult Edytuj()
        {
            var kategoria = new KategoriaForumModel
            {
                Id = 1,
                Nazwa = "Gry komputerowe",
                Opis = "test tets"
            };

            return View(kategoria);
        }

        // Obsługa formularza edycji kategorii
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edytuj(KategoriaForumModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            ViewBag.Komunikat = "Dane kategorii zostały poprawnie zmienione!";

            return View(model);
        }
    }
}