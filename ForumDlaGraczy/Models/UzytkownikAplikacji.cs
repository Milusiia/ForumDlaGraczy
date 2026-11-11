using Microsoft.AspNetCore.Identity;
namespace ForumDlaGraczy.Models;

public class UzytkownikAplikacji : IdentityUser
{
    public string? AvatarUrl { get; set; }
    public DateTime DataRejestracji { get; set; } = DateTime.Now;
    public string WybranaSkorka { get; set; } = "Ciemna"; 
    public int WiadomosciNaStrone { get; set; } = 10; 

    public virtual ICollection<Watek> Watki { get; set; } = new List<Watek>();
    public virtual ICollection<Odpowiedz> Posty { get; set; } = new List<Odpowiedz>();
}