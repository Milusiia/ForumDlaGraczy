using Microsoft.AspNetCore.Mvc;
using ForumDlaGraczy.Models;

namespace ForumDlaGraczy.Controllers
{
    public class AdministracjaTresciController : Controller
    {
        // Przykładowa lista wątków
        private static List<WatekAdministracyjnyModel> watki =
            new List<WatekAdministracyjnyModel>
        {
            new WatekAdministracyjnyModel
            {
                Id = 1,
                Tytul = "Jaką grę RPG polecacie?",
                Autor = "Gracz123",
                Podforum = "Gry RPG",
                DataUtworzenia = DateTime.Now.AddDays(-5),
                LiczbaOdslon = 25,
                CzyPrzypiety = false
            },

            new WatekAdministracyjnyModel
            {
                Id = 2,
                Tytul = "Problem z Minecraftem",
                Autor = "GamingMaster",
                Podforum = "Minecraft",
                DataUtworzenia = DateTime.Now.AddDays(-3),
                LiczbaOdslon = 48,
                CzyPrzypiety = true
            },

            new WatekAdministracyjnyModel
            {
                Id = 3,
                Tytul = "Jaki sprzęt gamingowy wybrać?",
                Autor = "ProPlayer",
                Podforum = "Sprzęt gamingowy",
                DataUtworzenia = DateTime.Now.AddDays(-1),
                LiczbaOdslon = 17,
                CzyPrzypiety = false
            }
        };

        // Przykładowe wiadomości
        private static List<WiadomoscAdministracyjnaModel> wiadomosci =
            new List<WiadomoscAdministracyjnaModel>
        {
            new WiadomoscAdministracyjnaModel
            {
                Id = 1,
                WatekId = 1,
                TytulWatku = "Jaką grę RPG polecacie?",
                Autor = "GamingMaster",
                Tresc = "Polecam Wiedźmina 3. To naprawdę świetna gra!",
                DataUtworzenia = DateTime.Now.AddDays(-4)
            },

            new WiadomoscAdministracyjnaModel
            {
                Id = 2,
                WatekId = 1,
                TytulWatku = "Jaką grę RPG polecacie?",
                Autor = "ProPlayer",
                Tresc = "Możesz też spróbować Skyrima.",
                DataUtworzenia = DateTime.Now.AddDays(-3)
            },

            new WiadomoscAdministracyjnaModel
            {
                Id = 3,
                WatekId = 2,
                TytulWatku = "Problem z Minecraftem",
                Autor = "Gracz123",
                Tresc = "Mam problem z uruchomieniem gry.",
                DataUtworzenia = DateTime.Now.AddDays(-2)
            },

            new WiadomoscAdministracyjnaModel
            {
                Id = 4,
                WatekId = 2,
                TytulWatku = "Problem z Minecraftem",
                Autor = "GamingMaster",
                Tresc = "Spróbuj zaktualizować sterowniki.",
                DataUtworzenia = DateTime.Now.AddDays(-1)
            }
        };

        // Wyświetlenie listy wszystkich wątków
        [HttpGet]
        public IActionResult Index()
        {
            foreach (var watek in watki)
            {
                watek.LiczbaOdpowiedzi =
                    wiadomosci.Count(w => w.WatekId == watek.Id);
            }

            return View(watki.OrderByDescending(w => w.DataUtworzenia).ToList());
        }

        // Wyświetlenie wiadomości w wybranym wątku
        [HttpGet]
        public IActionResult Wiadomosci(int id)
        {
            var watek = watki.FirstOrDefault(w => w.Id == id);

            if (watek == null)
            {
                return NotFound();
            }

            ViewBag.Watek = watek;

            var listaWiadomosci = wiadomosci
                .Where(w => w.WatekId == id)
                .OrderBy(w => w.DataUtworzenia)
                .ToList();

            return View(listaWiadomosci);
        }

        // Formularz edycji wiadomości
        [HttpGet]
        public IActionResult EdytujWiadomosc(int id)
        {
            var wiadomosc = wiadomosci.FirstOrDefault(w => w.Id == id);

            if (wiadomosc == null)
            {
                return NotFound();
            }

            return View(wiadomosc);
        }

        // Obsługa edycji wiadomości
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult EdytujWiadomosc(
            WiadomoscAdministracyjnaModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var wiadomosc = wiadomosci.FirstOrDefault(w => w.Id == model.Id);

            if (wiadomosc == null)
            {
                return NotFound();
            }

            wiadomosc.Tresc = model.Tresc;

            TempData["Komunikat"] = "Wiadomość została zmieniona!";

            return RedirectToAction(
                "Wiadomosci",
                new { id = wiadomosc.WatekId });
        }

        // Usuwanie wiadomości
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult UsunWiadomosc(int id)
        {
            var wiadomosc = wiadomosci.FirstOrDefault(w => w.Id == id);

            if (wiadomosc == null)
            {
                return NotFound();
            }

            int idWatku = wiadomosc.WatekId;

            wiadomosci.Remove(wiadomosc);

            TempData["Komunikat"] = "Wiadomość została usunięta!";

            return RedirectToAction(
                "Wiadomosci",
                new { id = idWatku });
        }
    }
}