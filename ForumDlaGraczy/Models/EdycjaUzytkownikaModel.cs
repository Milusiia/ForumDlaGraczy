using System.ComponentModel.DataAnnotations;

namespace ForumDlaGraczy.Models
{
    public class EdycjaUzytkownikaModel
    {
        public string Id { get; set; } = "";

        [Required(ErrorMessage = "Podaj nazwę użytkownika.")]
        [StringLength(50, ErrorMessage = "Nazwa może mieć maksymalnie 50 znaków.")]
        [Display(Name = "Nazwa użytkownika")]
        public string NazwaUzytkownika { get; set; } = "";

        [Required(ErrorMessage = "Podaj adres e-mail.")]
        [EmailAddress(ErrorMessage = "Podaj poprawny adres e-mail.")]
        [Display(Name = "Adres e-mail")]
        public string Email { get; set; } = "";
    }
}