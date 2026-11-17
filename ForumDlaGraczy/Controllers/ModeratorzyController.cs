using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using ForumDlaGraczy.Models;

namespace ForumDlaGraczy.Controllers
{
    public class ModeratorzyController : Controller
    {
        // Przykładowi użytkownicy
        private static Dictionary<int, string> uzytkownicy = new Dictionary<int, string>
        {
            { 1, "Gracz123" },
            { 2, "GamingMaster" },
            { 3, "ProPlayer" }
        };

        // Przykładowe podfora
        private static Dictionary<int, string> podfora = new Dictionary<int, string>
        {
            { 1, "Minecraft" },
            { 2, "Counter-Strike 2" },
            { 3, "League of Legends" }
        };

        // Przykładowe przypisania moderatorów
        private static List<PrzypisanieModeratoraModel> przypisania =
            new List<PrzypisanieModeratoraModel>
        {
            new PrzypisanieModeratoraModel
            {
                Id = 1,
                UzytkownikId = 1,
                PodforumId = 1
            },

            new PrzypisanieModeratoraModel
            {
                Id = 2,
                UzytkownikId = 2,
                PodforumId = 2
            }
        };

        private static int nastepneId = 3;

        // Przygotowanie list użytkowników i podforów
        private void PrzygotujListy()
        {
            ViewBag.Uzytkownicy = new List<SelectListItem>
            {
                new SelectListItem { Value = "1", Text = "Gracz123" },
                new SelectListItem { Value = "2", Text = "GamingMaster" },
                new SelectListItem { Value = "3", Text = "ProPlayer" }
            };

            ViewBag.Podfora = new List<SelectListItem>
            {
                new SelectListItem { Value = "1", Text = "Minecraft" },
                new SelectListItem { Value = "2", Text = "Counter-Strike 2" },
                new SelectListItem { Value = "3", Text = "League of Legends" }
            };

            ViewBag.NazwyUzytkownikow = uzytkownicy;
            ViewBag.NazwyPodforow = podfora;
        }

        // Wyświetlenie listy moderatorów
        [HttpGet]
        public IActionResult Index()
        {
            PrzygotujListy();

            return View(przypisania);
        }

        // Formularz przypisywania moderatora
        [HttpGet]
        public IActionResult Dodaj()
        {
            PrzygotujListy();

            return View();
        }

        // Obsługa przypisywania moderatora
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Dodaj(PrzypisanieModeratoraModel model)
        {
            PrzygotujListy();

            // Sprawdzenie, czy wybrany użytkownik istnieje
            if (model.UzytkownikId.HasValue &&
                !uzytkownicy.ContainsKey(model.UzytkownikId.Value))
            {
                ModelState.AddModelError("UzytkownikId", "Nieprawidłowy użytkownik.");
            }

            // Sprawdzenie, czy wybrane podforum istnieje
            if (model.PodforumId.HasValue &&
                !podfora.ContainsKey(model.PodforumId.Value))
            {
                ModelState.AddModelError("PodforumId", "Nieprawidłowe podforum.");
            }

            // Sprawdzenie, czy takie przypisanie już istnieje
            if (model.UzytkownikId.HasValue && model.PodforumId.HasValue)
            {
                bool istnieje = przypisania.Any(p =>
                    p.UzytkownikId == model.UzytkownikId &&
                    p.PodforumId == model.PodforumId);

                if (istnieje)
                {
                    ModelState.AddModelError("",
                        "Ten użytkownik jest już moderatorem tego podforum.");
                }
            }

            if (!ModelState.IsValid)
            {
                return View(model);
            }

            model.Id = nastepneId++;

            przypisania.Add(model);

            TempData["Komunikat"] = "Moderator został przypisany do podforum!";

            return RedirectToAction("Index");
        }

        // Odebranie uprawnień moderatora
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Usun(int id)
        {
            var przypisanie = przypisania.FirstOrDefault(p => p.Id == id);

            if (przypisanie != null)
            {
                przypisania.Remove(przypisanie);

                TempData["Komunikat"] = "Uprawnienia moderatora zostały odebrane!";
            }

            return RedirectToAction("Index");
        }
    }
}