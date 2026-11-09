using System.ComponentModel.DataAnnotations;

namespace ForumDlaGraczy.Models
{
    public class PrzypiecieWatkuModel
    {
        [Required(ErrorMessage = "Wybierz wątek.")]
        [Display(Name = "Wybierz wątek")]
        public int? WatekId { get; set; }

        [Display(Name = "Przypnij wątek na górze listy")]
        public bool CzyPrzypiety { get; set; }
    }
}