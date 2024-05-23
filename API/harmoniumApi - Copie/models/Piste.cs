using System.ComponentModel.DataAnnotations;

namespace harmoniumApi.models
{
    public class Piste
    {
        [Key]
        public int id_Piste { get; set; }
        public int id_morceau { get; set; }
        public string pNom { get; set; }
        public byte[]? pImg { get; set; }
    }
}
