using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace application_Musicale.Models
{
    internal class UTILISATEUR_MORCEAU
    {
        /// <summary>
        /// UN IDENTIFIANT POUR L'UTILISATEUR
        /// UN IDENTIFIANT POUR LE MORCEAU
        /// </summary>
        public int id_utilisateur {  get; set; }
        public int id_morceau { get; set; }

        public UTILISATEUR_MORCEAU(int unIdUtilisateur, int unIdMorceau)
        {
            id_utilisateur = unIdUtilisateur;
            id_morceau = unIdMorceau;
        }
    }
}
