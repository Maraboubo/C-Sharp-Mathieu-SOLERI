using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace affichageBddLibrairie.Models
{
    internal class Commande
    {
        /// <summary>
        /// NUMERO DE COMMANDE
        /// NUMERO DE CLIENT
        /// DATE DE COMMANDE
        /// DATE DE LIVRAISON SOUHAITEE
        /// DATE D ARRIVEE
        /// </summary>
        public int NumCo { get; set; }
        public string CliNum { get; set; }
        public DateOnly DateCo { get; set; }
        public DateOnly DateLivraiSouhait { get; set; }
        public DateOnly DateArrive { get; set; } 

        public Commande(int unNumCo, string unNumCli, DateOnly uneDateCo, DateOnly uneDateLivraiSouhait, DateOnly uneDateArrive) 
        {
            NumCo=unNumCo;
            CliNum=unNumCli;
            DateCo=uneDateCo;
            DateLivraiSouhait=uneDateLivraiSouhait;
            DateArrive=uneDateArrive;
        }
    }
}
