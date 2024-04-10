using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace application_Musicale.Models
{
    internal class VILLES
    {
        /// <summary>
        /// IDENTIFIANT POUR LE CODE POSTAL
        /// UN IDENTIFIANT POUR LE PAYS
        /// CODE POSTAL DE LA VILLE
        /// NOM DE LA VILLE
        /// </summary>
        public int id_vCode { get; set; }
        public int id_pNom { get; set; }
        public string vCode { get; set; }
        public string vNom { get; set; }

        public VILLES(int unIdVCode, int unIdPNom, string unVCode, string unVNom) 
        { 
            id_vCode = unIdVCode;
            id_pNom = unIdPNom;
            vCode = unVCode;
            vNom = unVNom;
        }
    }
}
