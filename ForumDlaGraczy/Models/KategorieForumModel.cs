using System.ComponentModel.DataAnnotations;

namespace ForumDlaGraczy.Models
{
    public class KategoriaForumModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Podaj nazwę kategorii.")]
        [StringLength(50, ErrorMessage = "Nazwa może mieć maksymalnie 50 znaków.")]
        [Display(Name = "Nazwa kategorii")]
        public string Nazwa { get; set; } = "";

        [StringLength(300, ErrorMessage = "Opis może mieć maksymalnie 300 znaków.")]
        [Display(Name = "Opis kategorii")]
        public string? Opis { get; set; }
    }
}