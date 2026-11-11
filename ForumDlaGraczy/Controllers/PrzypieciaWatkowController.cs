using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using ForumDlaGraczy.Models;

namespace ForumDlaGraczy.Controllers
{
    public class PrzypieciaWatkowController : Controller
    {
        private List<SelectListItem> PobierzWatki()
        {
            return new List<SelectListItem>
            {
                new SelectListItem { Value = "1", Text = "Test1" },
                new SelectListItem { Value = "2", Text = "Test2" },
                new SelectListItem { Value = "3", Text = "Test3" }
            };
        }

        // formularz przypinania wątku
        [HttpGet]
        public IActionResult Edytuj()
        {
            ViewBag.Watki = PobierzWatki();

            return View();
        }

        // Obsługa formularza przypinania wątku
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edytuj(PrzypiecieWatkuModel model)
        {
            ViewBag.Watki = PobierzWatki();

            if (!ModelState.IsValid)
            {
                return View(model);
            }

            if (model.CzyPrzypiety)
            {
                ViewBag.Komunikat = "Wątek został oznaczony do przypięcia!";
            }
            else
            {
                ViewBag.Komunikat = "Wątek został oznaczony do odpięcia!";
            }

            return View(model);
        }
    }
}