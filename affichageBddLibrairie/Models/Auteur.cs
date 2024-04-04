using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace affichageBddLibrairie.Models
{
    public class Auteur
    {
        /// <summary>
        /// IDENTIFIANT AUTEUR
        /// NOM DE L AUTEUR
        /// PRENOM DE L AUTEUR
        /// </summary>
        public int IdAuteur { get; set; }
        public string NomAuteur { get; set; }
        public string PrenomAuteur { get; set; }

        public Auteur(int unId, string unNom, string unPrenom)
        {
            IdAuteur = unId;
            NomAuteur = unNom;
            PrenomAuteur = unPrenom;
        }
    }
}
