using System.ComponentModel.DataAnnotations;

namespace harmoniumApi
{
    public class Album
    {
        [Key]
        public int id_album { get; set; }
        public string aNom { get; set; }
        public byte[]? aImg { get; set; }
    }
}
