using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace affichageBddLibrairie.Models
{
    internal class Document
    {
        /// <summary>
        /// IDENTIFIANT DE DOCUMENT
        /// DENOMINATION DU DOCUMENT
        /// DESCRIPTION DU DOCUMENT
        /// TITRE DU DOCUMENT
        /// URL DU DOCUMENT
        /// </summary>
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Title { get; set; }    
        public string Url { get; set; }

        public Document(int unId , string unName, string uneDescription, string unTitre, string uneUrl) 
        {
            Id = unId;
            Name = unName;
            Description = uneDescription;
            Title = unTitre;
            Url = uneUrl;
        }

    }
}
