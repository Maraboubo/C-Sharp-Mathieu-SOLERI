using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace application_Musicale.Models
{
    internal class COMPOSANT
    {
        /// <summary>
        /// IDENTIFIANT DU COMPOSANT
        /// NOM DU COMPOSANT
        /// DATE DE CREATION DU COMPOSANT
        /// DATE DE MODIFICATION DU COMPOSANT
        /// IMAGE/ILLUSTRATION DU COMPOSANT
        /// FICHIER AUDIO DU COMPOSANT
        /// </summary>
        public int id_Composant { get; set; }
        public string cNom { get; set; }
        public DateTime cDateCrea { get; set; }
        public DateTime? cDateModif { get; set; }
        public byte[]? cImg { get; set; }
        public byte[]? cFich { get; set; }

        public COMPOSANT( int unIdComposant,  string unNomDeComposant, DateTime uneDateDeCreation, DateTime? uneDateDeModification, byte[]? uneImageDeComposant, byte[]? unFichierDeComposant) 
        {
            id_Composant = unIdComposant;
            cNom = unNomDeComposant;
            cDateCrea = uneDateDeCreation;
            cDateModif = uneDateDeModification;
            cImg = uneImageDeComposant;
            cFich = unFichierDeComposant;
        }
    }
}
