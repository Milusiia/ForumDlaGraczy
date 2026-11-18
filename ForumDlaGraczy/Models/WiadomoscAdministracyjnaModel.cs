using System.ComponentModel.DataAnnotations;

namespace ForumDlaGraczy.Models
{
    public class WiadomoscAdministracyjnaModel
    {
        public int Id { get; set; }

        public int WatekId { get; set; }

        public string TytulWatku { get; set; } = "";

        public string Autor { get; set; } = "";

        [Required(ErrorMessage = "Treść wiadomości nie może być pusta.")]
        [StringLength(2000, ErrorMessage = "Wiadomość może mieć maksymalnie 2000 znaków.")]
        [Display(Name = "Treść wiadomości")]
        public string Tresc { get; set; } = "";

        public DateTime DataUtworzenia { get; set; }
    }
}