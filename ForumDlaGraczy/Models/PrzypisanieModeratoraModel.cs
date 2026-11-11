using System.ComponentModel.DataAnnotations;

namespace ForumDlaGraczy.Models
{
    public class PrzypisanieModeratoraModel
    {
        [Required(ErrorMessage = "Wybierz użytkownika.")]
        [Display(Name = "Użytkownik")]
        public int? UzytkownikId { get; set; }

        [Required(ErrorMessage = "Wybierz podforum.")]
        [Display(Name = "Podforum")]
        public int? PodforumId { get; set; }
    }
}