namespace harmoniumApi.models
{
    public class UtilisateurCreationDto
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string motDePasse { get; set; }
        public string Nom { get; set; }
        public string Prenom { get; set; }
        public string Adresse1 { get; set; }
        public string? Adresse2 { get; set; }
        public int CodePostal { get; set; }
        public string Ville { get; set; }
        public List<int> InstrumentIds { get; set; }
    }
}
