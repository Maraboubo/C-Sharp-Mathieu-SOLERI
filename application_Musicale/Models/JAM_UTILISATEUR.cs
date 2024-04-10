using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace application_Musicale.Models
{
    internal class JAM_UTILISATEUR
    {
        /// <summary>
        /// ID POUR UNE JAM
        /// ID POUR UN UTILISATEUR
        /// </summary>
        public int id_jam { get; set; }
        public int id_utilisateur { get; set; }

        public JAM_UTILISATEUR(int unid_jam, int unid_utilisateur) 
        {
            id_jam = unid_jam;
            id_utilisateur = unid_utilisateur;
        }
    }
}
