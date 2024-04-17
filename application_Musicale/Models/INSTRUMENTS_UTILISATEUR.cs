using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace application_Musicale.Models
{
    internal class INSTRUMENTS_UTILISATEUR
    {
        /// <summary>
        /// IDENTIFIANT POUR L'INSTRUMENT
        /// IDENTIFIANT POUR L'UTILISATEUR
        /// </summary>
        public int id_instrument {  get; set; }
        public int id_utilisateur { get; set;}

        public INSTRUMENTS_UTILISATEUR(int unIdInstrument, int unIdUtilisateur )
        {
            id_instrument = unIdInstrument;
            id_utilisateur = unIdUtilisateur;
        }
    }
}
