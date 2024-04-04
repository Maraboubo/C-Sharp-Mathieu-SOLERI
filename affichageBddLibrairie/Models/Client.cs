using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace affichageBddLibrairie.Models
{
    internal class Client
    {
        /// <summary>
        /// NUMERO CLIENT
        /// IDENTIFIANT DE RAISON SOCIALE DU CLIENT
        /// PRENOM DU CLIENT
        /// ADRESSE LIGNE 1 DU CLIENT
        /// ADRESSE LIGNE 2 DU CLIENT
        /// </summary>
        public int NumCli { get; set; }
        public int so_id { get; set; }
        public string NomCli { get; set; }
        public string PrenomCli { get; set; }
        public string Adress1 { get; set; }
        public string Adress2 { get; set;}

        public Client(int unNumeroCli, int unIdCli, string unNomCli, string unPrenomCli, string uneAdresseUnCli, string uneAdresseDeuxCli) 
        {
            NumCli=unNumeroCli;
            so_id=unIdCli;
            NomCli=unNomCli;
            PrenomCli=unPrenomCli;
            Adress1=uneAdresseUnCli;
            Adress2=uneAdresseDeuxCli;
        }
    }
}
