using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace application_Musicale.Models
{
    internal class INSTRUMENTS
    {
        /// <summary>
        /// IDENTIFIANT POUR L'INSTRUMENT
        /// IDENTIFIANT POUR L'UTILISATEUR
        /// </summary>
        public int id_instrument {  get; set; }
        public string iNom { get; set; }

        public INSTRUMENTS(int unIdIntrument, string unINom) 
        {
            id_instrument = unIdIntrument;
            iNom = unINom;
        }

    }
}
