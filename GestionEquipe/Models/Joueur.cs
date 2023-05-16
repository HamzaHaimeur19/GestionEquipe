namespace GestionEquipe.Models
{
    public class Joueur
    {
        public int Id { get; set; }
        public string Nom { get; set; }
        public string Prenom { get; set; }
        public int No { get; set; }
        public int IdEquipe { get; set; }
    }
}
