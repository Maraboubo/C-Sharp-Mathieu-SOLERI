using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace application_Musicale.Models
{
    internal class PAYS
    {
        /// <summary>
        /// IDENTIFIANT POUR LE NOM DU PAYS
        /// NOM DU PAYS
        /// </summary>
        public int id_pNom { get; set; }
        public string pNom { get; set; }

        public PAYS(int unIdPNom, string unPNom) 
        {
            id_pNom = unIdPNom;
            pNom=unPNom;
        }


    }
}
