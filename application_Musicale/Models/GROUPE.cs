using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace application_Musicale.Models
{
    internal class GROUPE
    {
        /// <summary>
        /// IDENTIFIANT DU GROUPE
        /// NOM DU GROUPE
        /// DATE DE CREATION DU GROUPE
        /// </summary>
        public int id_groupe { get; set; }
        public string gNom { get; set; }
        public DateTime gDate { get; set; }

        public GROUPE(int unIdGroupe, string unGNom, DateTime unGDate) 
        {
            id_groupe= unIdGroupe;
            gNom= unGNom;
            gDate= unGDate;
        }


    }
}
