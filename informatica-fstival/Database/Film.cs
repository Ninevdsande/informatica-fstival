namespace informatica_fstival.Database
{
    public class Film
    {
        public int Id { get; set; }

        public string Titel { get; set; }

        public string Beschrijving { get; set; }

        public string Regisseur { get; set; }

        public string Cast { get; set; }

        public string Poster { get; set; }
        
        public int Beschikbaarheid { get; set; }
    }
}