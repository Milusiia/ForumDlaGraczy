namespace ForumDlaGraczy.Models
{
    public class WatekAdministracyjnyModel
    {
        public int Id { get; set; }

        public string Tytul { get; set; } = "";

        public string Autor { get; set; } = "";

        public string Podforum { get; set; } = "";

        public DateTime DataUtworzenia { get; set; }

        public int LiczbaOdslon { get; set; }

        public bool CzyPrzypiety { get; set; }

        public int LiczbaOdpowiedzi { get; set; }
    }
}