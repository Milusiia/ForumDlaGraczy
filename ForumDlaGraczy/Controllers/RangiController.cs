using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using ForumDlaGraczy.Models;

namespace ForumDlaGraczy.Controllers
{
	public class RangiController : Controller
	{
		// Przykładowi użytkownicy i rangi
		private void PrzygotujListy()
		{
			ViewBag.Uzytkownicy = new List<SelectListItem>
			{
				new SelectListItem { Value = "1", Text = "Gracz123" },
				new SelectListItem { Value = "2", Text = "GamingMaster" },
				new SelectListItem { Value = "3", Text = "ProPlayer" }
			};

			ViewBag.Rangi = new List<SelectListItem>
			{
				new SelectListItem { Value = "Nowicjusz", Text = "Nowicjusz" },
				new SelectListItem { Value = "Aktywny gracz", Text = "Aktywny gracz" },
				new SelectListItem { Value = "Stały bywalec", Text = "Stały bywalec" },
				new SelectListItem { Value = "Weteran forum", Text = "Weteran forum" }
			};
		}

        // Formularza zmiany rangi
        [HttpGet]
		public IActionResult Edytuj()
		{
			PrzygotujListy();

			return View();
		}

		// Obsługa formularza zmiany rangi
		[HttpPost]
		[ValidateAntiForgeryToken]
		public IActionResult Edytuj(ZmianaRangiModel model)
		{
			PrzygotujListy();

			if (!ModelState.IsValid)
			{
				return View(model);
			}

			ViewBag.Komunikat = "Ranga użytkownika została poprawnie wybrana!";

			return View(model);
		}
	}
}