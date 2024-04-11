using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace application_Musicale.Models
{
    internal class MORCEAU
    {
        /// <summary>
        /// IDENTIFIANT POUR LE MORCEAU
        /// IDENTIFIANT POUR L'ALBUM
        /// IDENTIFIANT POUR L'UTILISATEUR
        /// IDENTIFIANT POUR LE GROUPE
        /// NOM DU MORCEAU
        /// IMAGE/ILLUSTRATION DU MORCEAU
        /// </summary>
        public int id_morceau { get; set; }
        public int id_album { get; set; }
        public int? id_utilisateur { get; set; }
        public int? id_groupe { get; set; }
        public string mNom { get; set; }
        public byte[]? mImg { get; set; }

        public MORCEAU (int unIdMorceau, int unIdAlbum, int? unIdUtilisateur, int? unIdGroupe, string unMNom, byte[]? unMImg)
        {
            id_morceau = unIdMorceau;
            id_album = unIdAlbum;
            id_utilisateur = unIdUtilisateur;
            id_groupe = unIdGroupe;
            mNom = unMNom;
            mImg = unMImg;
        }
    }
}
