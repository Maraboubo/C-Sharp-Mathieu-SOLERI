using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace affichageBddLibrairie.Models
{
    internal class RaisonSociale
    {
        /// <summary>
        /// IDENTIFIANT DE LA RAISON SOCIALE
        /// LIBELLE DE LA RAISON SOCIALE
        /// </summary>
        public int IdSo { get; set; }
        public string RaisonSolib { get; set; }

        public RaisonSociale(int unIdSo, string unLibRaiSoc) 
        {
            IdSo = unIdSo;
            RaisonSolib = unLibRaiSoc;
        }

    }
}
