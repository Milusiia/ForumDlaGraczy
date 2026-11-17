using System.ComponentModel.DataAnnotations;

namespace ForumDlaGraczy.Models;

public class Odpowiedz
{
    public int Id { get; set; }

    [Required(ErrorMessage = "Treść nie może być pusta")]
    public string Tresc { get; set; } = "";

    public DateTime DataUtworzenia { get; set; } = DateTime.Now;

    // Kto napisał
    public string UzytkownikAplikacjiId { get; set; } = "";
    public virtual UzytkownikAplikacji? Autor { get; set; }

    // W jakim wątku
    public int WatekId { get; set; }
    public virtual Watek? Temat { get; set; }
}