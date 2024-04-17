using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace application_Musicale.Models
{
    internal class STYLE_MORCEAU
    {
        /// <summary>
        /// IDENTIFIANT POUR LE STYLE DE MUSIQUE
        /// IDENTIFIANT POUR LE GROUPE DE MUSIQUE
        /// </summary>
        public int id_style {  get; set; }
        public int id_morceau { get; set; }

        public STYLE_MORCEAU (int unIdStyle, int unIdMorceau)
        {
            id_style = unIdStyle;
            id_morceau = unIdMorceau;
        }
    }
}
