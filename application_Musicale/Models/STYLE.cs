using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace application_Musicale.Models
{
    /// <summary>
    /// IDENTIFIANT POUR LE STYLE DE MUSIQUE
    /// NOM DU STYLE DE MUSIQUE
    /// </summary>
    internal class STYLE
    {
        public int id_style {  get; set; }
        public string sNom { get; set; }

        public STYLE (int unIdStyle, string unSNom)
        {
            this.id_style = unIdStyle;
            this.sNom = unSNom;
        }
    }
}
