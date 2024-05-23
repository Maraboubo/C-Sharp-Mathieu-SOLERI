using System.ComponentModel.DataAnnotations;

namespace testCommunicationSqlServer
{
    public class Utilisateurs
    {
        [Key]
        public int id {  get; set; }
        public string nom { get; set; }
        public string prenom { get; set; }

    }
}
