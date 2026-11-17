using System.ComponentModel.DataAnnotations;

namespace ForumDlaGraczy.Models;

public class Watek
{
    public int Id { get; set; }

    [Required(ErrorMessage = "Podaj tytuł wątku")]
    [StringLength(100)]
    public string Tytul { get; set; } = "";

    public DateTime DataUtworzenia { get; set; } = DateTime.Now;
    public int LiczbaOdslon { get; set; } = 0;
    public bool CzyPrzypiety { get; set; } = false;

    // Kto założył wątek
    public string UzytkownikAplikacjiId { get; set; } = "";
    public virtual UzytkownikAplikacji? Autor { get; set; }

    // Do jakiego podforum należy
    public int PodforumId { get; set; }
    public virtual PodforumModel? Podforum { get; set; }

    // Lista odpowiedzi w wątku
    public virtual ICollection<Odpowiedz> Posty { get; set; } = new List<Odpowiedz>();
}