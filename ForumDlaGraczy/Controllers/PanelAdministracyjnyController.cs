using Microsoft.AspNetCore.Mvc;

namespace ForumDlaGraczy.Controllers
{
    public class PanelAdministracyjnyController : Controller
    {
        // Wyświetlenie strony głównej panelu
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
    }
}