using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using ForumDlaGraczy.Models;

namespace ForumDlaGraczy.Controllers
{
    [Authorize(Roles = "Administrator")]
    public class UzytkownicyController : Controller
    {
        private readonly UserManager<UzytkownikAplikacji> _userManager;

        public UzytkownicyController(
            UserManager<UzytkownikAplikacji> userManager)
        {
            _userManager = userManager;
        }

        // Wyświetlenie listy użytkowników
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var uzytkownicy = await _userManager.Users
                .OrderBy(u => u.UserName)
                .ToListAsync();

            return View(uzytkownicy);
        }

        // Wyświetlenie szczegółów użytkownika
        [HttpGet]
        public async Task<IActionResult> Szczegoly(string id)
        {
            var uzytkownik = await _userManager.FindByIdAsync(id);

            if (uzytkownik == null)
            {
                return NotFound();
            }

            return View(uzytkownik);
        }

        // Formularz edycji użytkownika
        [HttpGet]
        public async Task<IActionResult> Edytuj(string id)
        {
            var uzytkownik = await _userManager.FindByIdAsync(id);

            if (uzytkownik == null)
            {
                return NotFound();
            }

            var model = new EdycjaUzytkownikaModel
            {
                Id = uzytkownik.Id,
                NazwaUzytkownika = uzytkownik.UserName ?? "",
                Email = uzytkownik.Email ?? ""
            };

            return View(model);
        }

        // Obsługa edycji użytkownika
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edytuj(
            string id,
            EdycjaUzytkownikaModel model)
        {
            if (id != model.Id)
            {
                return BadRequest();
            }

            var uzytkownik = await _userManager.FindByIdAsync(id);

            if (uzytkownik == null)
            {
                return NotFound();
            }

            if (!ModelState.IsValid)
            {
                return View(model);
            }

            // Sprawdzenie, czy adres e-mail nie należy do innego konta
            var istniejeEmail = await _userManager.FindByEmailAsync(model.Email);

            if (istniejeEmail != null && istniejeEmail.Id != id)
            {
                ModelState.AddModelError(
                    "Email",
                    "Ten adres e-mail jest już używany.");

                return View(model);
            }

            uzytkownik.UserName = model.NazwaUzytkownika;
            uzytkownik.Email = model.Email;

            var wynik = await _userManager.UpdateAsync(uzytkownik);

            if (!wynik.Succeeded)
            {
                foreach (var blad in wynik.Errors)
                {
                    ModelState.AddModelError("", blad.Description);
                }

                return View(model);
            }

            TempData["Komunikat"] = "Dane użytkownika zostały zmienione!";

            return RedirectToAction("Szczegoly", new { id = uzytkownik.Id });
        }

        // Blokowanie konta użytkownika
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Zablokuj(string id)
        {
            var uzytkownik = await _userManager.FindByIdAsync(id);

            if (uzytkownik == null)
            {
                return NotFound();
            }

            // Administrator nie może zablokować własnego konta
            if (_userManager.GetUserId(User) == uzytkownik.Id)
            {
                TempData["Komunikat"] = "Nie możesz zablokować własnego konta!";

                return RedirectToAction("Index");
            }

            var wynikWlaczenia = await _userManager.SetLockoutEnabledAsync(
                uzytkownik, true);

            if (wynikWlaczenia.Succeeded)
            {
                var wynik = await _userManager.SetLockoutEndDateAsync(
                    uzytkownik, DateTimeOffset.MaxValue);

                if (wynik.Succeeded)
                {
                    TempData["Komunikat"] = "Konto użytkownika zostało zablokowane!";
                }
                else
                {
                    TempData["Komunikat"] = "Nie udało się zablokować konta.";
                }
            }

            return RedirectToAction("Index");
        }

        // Odblokowanie konta użytkownika
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Odblokuj(string id)
        {
            var uzytkownik = await _userManager.FindByIdAsync(id);

            if (uzytkownik == null)
            {
                return NotFound();
            }

            var wynik = await _userManager.SetLockoutEndDateAsync(
                uzytkownik, null);

            if (wynik.Succeeded)
            {
                TempData["Komunikat"] = "Konto użytkownika zostało odblokowane!";
            }
            else
            {
                TempData["Komunikat"] = "Nie udało się odblokować konta.";
            }

            return RedirectToAction("Index");
        }
    }
}