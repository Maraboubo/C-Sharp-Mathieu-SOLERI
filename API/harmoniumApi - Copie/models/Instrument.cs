using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace harmoniumApi.models
{
    public class Instrument
    {
        //[Key]
        public int Id { get; set; }
        public string Nom { get; set; }
        public ICollection<InstrumentUtilisateur> InstrumentUtilisateurs { get; set; }
    }
}
