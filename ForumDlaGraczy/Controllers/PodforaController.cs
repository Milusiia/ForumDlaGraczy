using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using ForumDlaGraczy.Models;

namespace ForumDlaGraczy.Controllers
{
    public class PodforaController : Controller
    {
        // Przykładowa lista podforów
        private static List<PodforumModel> podfora = new List<PodforumModel>
        {
            new PodforumModel
            {
                Id = 1,
                Nazwa = "Minecraft",
                Opis = "Dyskusje o grze Minecraft.",
                KategoriaForumId = 2
            },

            new PodforumModel
            {
                Id = 2,
                Nazwa = "Counter-Strike 2",
                Opis = "Rozmowy o Counter-Strike 2.",
                KategoriaForumId = 2
            },

            new PodforumModel
            {
                Id = 3,
                Nazwa = "PlayStation 5",
                Opis = "Dyskusje o konsoli PlayStation.",
                KategoriaForumId = 3
            }
        };

        // Id kolejnego podforum
        private static int nastepneId = 4;

        // Przygotowanie listy kategorii
        private List<SelectListItem> PobierzKategorie()
        {
            return new List<SelectListItem>
            {
                new SelectListItem { Value = "1", Text = "Gry komputerowe" },
                new SelectListItem { Value = "2", Text = "Gry multiplayer" },
                new SelectListItem { Value = "3", Text = "Konsole" },
                new SelectListItem { Value = "4", Text = "Sprzęt gamingowy" }
            };
        }

        // Przygotowanie nazw kategorii do wyświetlenia
        private void PrzygotujNazwyKategorii()
        {
            ViewBag.NazwyKategorii = new Dictionary<int, string>
            {
                { 1, "Gry komputerowe" },
                { 2, "Gry multiplayer" },
                { 3, "Konsole" },
                { 4, "Sprzęt gamingowy" }
            };
        }

        // Wyświetlenie listy podforów
        [HttpGet]
        public IActionResult Index()
        {
            PrzygotujNazwyKategorii();

            return View(podfora);
        }

        // Formularz dodawania podforum
        [HttpGet]
        public IActionResult Dodaj()
        {
            ViewBag.Kategorie = PobierzKategorie();

            return View();
        }

        // Obsługa dodawania podforum
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Dodaj(PodforumModel model)
        {
            ViewBag.Kategorie = PobierzKategorie();

            if (!ModelState.IsValid)
            {
                return View(model);
            }

            model.Id = nastepneId++;

            podfora.Add(model);

            TempData["Komunikat"] = "Podforum zostało dodane!";

            return RedirectToAction("Index");
        }

        // Formularz edycji podforum
        [HttpGet]
        public IActionResult Edytuj(int id)
        {
            ViewBag.Kategorie = PobierzKategorie();

            var podforum = podfora.FirstOrDefault(p => p.Id == id);

            if (podforum == null)
            {
                return NotFound();
            }

            return View(podforum);
        }

        // Obsługa edycji podforum
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edytuj(PodforumModel model)
        {
            ViewBag.Kategorie = PobierzKategorie();

            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var podforum = podfora.FirstOrDefault(p => p.Id == model.Id);

            if (podforum == null)
            {
                return NotFound();
            }

            podforum.Nazwa = model.Nazwa;
            podforum.Opis = model.Opis;
            podforum.KategoriaForumId = model.KategoriaForumId;

            TempData["Komunikat"] = "Podforum zostało zmienione!";

            return RedirectToAction("Index");
        }

        // Usuwanie podforum
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Usun(int id)
        {
            var podforum = podfora.FirstOrDefault(p => p.Id == id);

            if (podforum != null)
            {
                podfora.Remove(podforum);

                TempData["Komunikat"] = "Podforum zostało usunięte!";
            }

            return RedirectToAction("Index");
        }
    }
}