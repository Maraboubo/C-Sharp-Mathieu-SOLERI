using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.Metrics;

namespace harmoniumApi.models
{
    [PrimaryKey(nameof(UtilisateurId), nameof(InstrumentId))]
    public class InstrumentUtilisateur
    {
        public int UtilisateurId { get; set; }
        //public Utilisateurs Utilisateur { get; set; }
        public int InstrumentId { get; set; }
        //public Instrument Instrument { get; set; }
    }
}
