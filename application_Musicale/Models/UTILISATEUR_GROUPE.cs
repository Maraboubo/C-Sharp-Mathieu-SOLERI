using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace application_Musicale.Models
{
    internal class UTILISATEUR_GROUPE
    {
        /// <summary>
        /// UN ID UTILISATEUR
        /// UN ID DE GROUPE
        /// EST CE QUE L'UTILISATEUR EST ADMINISTRATEUR DE GROUPE
        /// </summary>
        public int id_utilisateur { get; set; }
        public int id_groupe { get; set; }
        public bool gAdmin { get; set; }

        public UTILISATEUR_GROUPE(int unIdUtilisateur, int unIdGroupe, bool unGAdmin) 
        {
            id_utilisateur = unIdUtilisateur;
            id_groupe = unIdGroupe;
            gAdmin = unGAdmin;
        }
    }
}
