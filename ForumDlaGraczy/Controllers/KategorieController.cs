using Microsoft.AspNetCore.Mvc;
using ForumDlaGraczy.Models;

namespace ForumDlaGraczy.Controllers
{
    public class KategorieController : Controller
    {
        // Przykładowa lista kategorii
        private static List<KategoriaForumModel> kategorie = new List<KategoriaForumModel>
        {
            new KategoriaForumModel
            {
                Id = 1,
                Nazwa = "Gry komputerowe",
                Opis = "Dyskusje o grach komputerowych."
            },

            new KategoriaForumModel
            {
                Id = 2,
                Nazwa = "Gry multiplayer",
                Opis = "Rozmowy o grach wieloosobowych."
            },

            new KategoriaForumModel
            {
                Id = 3,
                Nazwa = "Konsole",
                Opis = "Dyskusje o konsolach."
            },

            new KategoriaForumModel
            {
                Id = 4,
                Nazwa = "Sprzęt gamingowy",
                Opis = "Rozmowy o sprzęcie dla graczy."
            }
        };

        private static int nastepneId = 5;

        // Wyświetlenie listy kategorii
        [HttpGet]
        public IActionResult Index()
        {
            return View(kategorie);
        }

        // Formularz dodawania kategorii
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

            model.Id = nastepneId++;
            kategorie.Add(model);

            TempData["Komunikat"] = "Kategoria została dodana!";

            return RedirectToAction("Index");
        }

        // Formularz edycji kategorii
        [HttpGet]
        public IActionResult Edytuj(int id)
        {
            var kategoria = kategorie.FirstOrDefault(k => k.Id == id);

            if (kategoria == null)
            {
                return NotFound();
            }

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

            var kategoria = kategorie.FirstOrDefault(k => k.Id == model.Id);

            if (kategoria == null)
            {
                return NotFound();
            }

            kategoria.Nazwa = model.Nazwa;
            kategoria.Opis = model.Opis;

            TempData["Komunikat"] = "Kategoria została zmieniona!";

            return RedirectToAction("Index");
        }

        // Usuwanie kategorii
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Usun(int id)
        {
            var kategoria = kategorie.FirstOrDefault(k => k.Id == id);

            if (kategoria != null)
            {
                kategorie.Remove(kategoria);
                TempData["Komunikat"] = "Kategoria została usunięta!";
            }

            return RedirectToAction("Index");
        }
    }
}