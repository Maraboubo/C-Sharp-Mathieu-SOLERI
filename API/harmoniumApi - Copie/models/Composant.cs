using System.ComponentModel.DataAnnotations;

namespace harmoniumApi.models
{
    public class Composant
    {
        [Key]
        public int id_composant { get; set; }
        public string cNom { get; set; }
        public DateTime cDateCrea { get; set; }
        public DateTime? cDateModif { get; set; }
        public byte[]? cImg { get; set; }
        public byte[]? cFich { get; set; }
    }
}
