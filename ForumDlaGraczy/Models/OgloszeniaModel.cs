using System.ComponentModel.DataAnnotations;

namespace ForumDlaGraczy.Models
{
    public class OgloszenieModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Podaj tytuł ogłoszenia.")]
        [StringLength(100, ErrorMessage = "Tytuł może mieć maksymalnie 100 znaków.")]
        [Display(Name = "Tytuł ogłoszenia")]
        public string Tytul { get; set; } = "";

        [Required(ErrorMessage = "Podaj treść ogłoszenia.")]
        [StringLength(1000, ErrorMessage = "Treść może mieć maksymalnie 1000 znaków.")]
        [Display(Name = "Treść ogłoszenia")]
        public string Tresc { get; set; } = "";
    }
}