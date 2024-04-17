using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace application_Musicale.Models
{
    /// <summary>
    /// IDENTIFIANT POUR LE STYLE DE MUSIQUE
    /// IDENTIFIANT POUR LE GROUPE DE MUSIQUE
    /// </summary>
    internal class STYLE_GROUPE
    {
        public int id_style {  get; set; }
        public int id_groupe { get; set; }

        public STYLE_GROUPE (int unIdSyle, int unIdGroupe)
        {
            id_groupe = unIdGroupe;
            id_style = unIdSyle;
        }
    }
}
