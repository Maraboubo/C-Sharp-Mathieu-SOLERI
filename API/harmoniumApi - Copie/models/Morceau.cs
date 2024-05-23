using System.ComponentModel.DataAnnotations;

namespace harmoniumApi.models
{

    public class Morceau
    {
        [Key]
        public int id_morceau { get; set; }
        public int? id_album { get; set; }
        public int id_utilisateur { get; set; }
        public int? id_groupe { get; set; }
        public string mNom { get; set; }
        public byte[]? mImg { get; set; }
    }
}
