using System.ComponentModel.DataAnnotations;

namespace harmoniumApi
{
    public class Jam
    {
        [Key]
        public int id_jam { get; set; }
        public string jNom { get; set; }
        public DateTime jDateCrea { get; set; }
        public DateTime? jDateDif { get; set; }
        public TimeOnly? jDur { get; set; }
        public string? jLink { get; set; }
    }
}
