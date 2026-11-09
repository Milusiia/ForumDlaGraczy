using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using ForumDlaGraczy.Models;

namespace ForumDlaGraczy.Controllers
{
    public class ModeratorzyController : Controller
    {
        private void PrzygotujListy()
        {
            ViewBag.Uzytkownicy = new List<SelectListItem>
            {
                new SelectListItem { Value = "1", Text = "Gracz1" },
                new SelectListItem { Value = "2", Text = "Gracz2" },
                new SelectListItem { Value = "3", Text = "Gracz3" }
            };

            ViewBag.Podfora = new List<SelectListItem>
            {
                new SelectListItem { Value = "1", Text = "Minecraft" },
                new SelectListItem { Value = "2", Text = "The Sims" },
                new SelectListItem { Value = "3", Text = "League of Legends" }
            };
        }

        // formularz przypisywania moderatora
        [HttpGet]
        public IActionResult Dodaj()
        {
            PrzygotujListy();

            return View();
        }

        // Obsługa formularza przypisywania moderatora
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Dodaj(PrzypisanieModeratoraModel model)
        {
            PrzygotujListy();

            if (!ModelState.IsValid)
            {
                return View(model);
            }

            ViewBag.Komunikat = "Dane przypisania moderatora są poprawne!";

            return View(model);
        }
    }
}