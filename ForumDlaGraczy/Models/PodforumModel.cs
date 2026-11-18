using System.ComponentModel.DataAnnotations;

namespace ForumDlaGraczy.Models
{
    public class PodforumModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Podaj nazwę podforum.")]
        [StringLength(60, ErrorMessage = "Nazwa może mieć maksymalnie 60 znaków.")]
        [Display(Name = "Nazwa podforum")]
        public string Nazwa { get; set; } = "";

        [StringLength(300, ErrorMessage = "Opis może mieć maksymalnie 300 znaków.")]
        [Display(Name = "Opis podforum")]
        public string? Opis { get; set; }

        [Required(ErrorMessage = "Wybierz kategorię.")]
        [Display(Name = "Kategoria")]
        public int? KategoriaForumId { get; set; }

        // Uprawnienia użytkowników niezalogowanych
        [Display(Name = "Anonimowi mogą przeglądać wiadomości")]
        public bool CzyAnonimowiMogaOgladac { get; set; } = true;

        [Display(Name = "Anonimowi mogą publikować wiadomości")]
        public bool CzyAnonimowiMogaPisac { get; set; } = false;
    }
}