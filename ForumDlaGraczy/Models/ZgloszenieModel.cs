using System.ComponentModel.DataAnnotations;

namespace ForumDlaGraczy.Models
{
    public class ZgloszenieModel
    {
        public int Id { get; set; }

        [Display(Name = "Numer wiadomości")]
        public int WiadomoscId { get; set; }

        [Display(Name = "Osoba zgłaszająca")]
        public string AutorZglaszajacy { get; set; } = "";

        [Display(Name = "Autor wiadomości")]
        public string AutorWiadomosci { get; set; } = "";

        [Display(Name = "Treść zgłoszonej wiadomości")]
        public string TrescWiadomosci { get; set; } = "";

        [Required(ErrorMessage = "Podaj powód zgłoszenia.")]
        [StringLength(300, ErrorMessage = "Powód może mieć maksymalnie 300 znaków.")]
        [Display(Name = "Powód zgłoszenia")]
        public string Powod { get; set; } = "";

        [Display(Name = "Status zgłoszenia")]
        public string Status { get; set; } = "Oczekujące";
    }
}