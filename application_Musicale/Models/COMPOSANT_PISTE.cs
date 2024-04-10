using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace application_Musicale.Models
{


    internal class COMPOSANT_PISTE
    {
        /// <summary>
        /// IDENTIFIANT POUR LA PISTE
        /// IDENTIFIANT POUR LE COMPOSANT
        /// MESURE ET SOUS MESURE DU COMPOSANT
        /// POSITION TEMPORELLE DU COMPOSANT
        /// </summary>
        public int id_piste { get; set; }
        public int id_Composant { get; set; }
        public float? cPosMes { get; set; }
        public TimeSpan? cPosTemp { get; set; }

        public COMPOSANT_PISTE(int unIdPiste, int unIdComposant, float? unCPosMes, TimeSpan? unCPosTemp)
        {
            id_piste= unIdPiste;
            id_Composant= unIdComposant;
            cPosMes= unCPosMes;
            cPosTemp= unCPosTemp;
        }
    }
}
