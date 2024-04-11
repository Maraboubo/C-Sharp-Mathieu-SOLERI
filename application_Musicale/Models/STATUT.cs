using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace application_Musicale.Models
{
    internal class STATUT
    {
        /// <summary>
        /// IDENTIFIANT POUR LE STATUT
        /// NOM DU STATUT
        /// </summary>
        public int id_statut {  get; set; }
        public string sNom { get; set; }

        public STATUT(int unIdStatut, string unSNom)
        {
            id_statut = unIdStatut;
            sNom = unSNom;
        }
    }
}
