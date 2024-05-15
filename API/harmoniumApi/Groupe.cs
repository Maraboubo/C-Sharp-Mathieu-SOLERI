using System.ComponentModel.DataAnnotations;

namespace harmoniumApi
{
    public class Groupe
    {
        [Key]
        public int Id_Groupe { get; set; }
        public string gNom { get; set; }
        public DateTime gDate { get; set; }
    }
}
