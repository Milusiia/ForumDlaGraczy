using System.ComponentModel.DataAnnotations;

namespace ForumDlaGraczy.Models
{
    public class ZmianaRangiModel
    {
        [Required(ErrorMessage = "Wybierz użytkownika.")]
        [Display(Name = "Użytkownik")]
        public int? UzytkownikId { get; set; }
        
        [Required(ErrorMessage = "Wybierz rangę.")]
        [Display(Name = "Nowa ranga")]
        public string Ranga { get; set; } = "";
    }
}