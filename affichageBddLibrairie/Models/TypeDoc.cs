using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace affichageBddLibrairie.Models
{
    internal class TypeDoc
    {
        /// <summary>
        /// IDENTIFIANT DU LIBELLE DE DOCUMENT
        /// LIBELLE DU DOCUMENT
        /// </summary>
        public int CodeType { get; set; }
        public string LibelleType { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="unCodeType"></param>
        /// <param name="unLibelleType"></param>
        public TypeDoc( int unCodeType, string unLibelleType )
        {
            CodeType = unCodeType;
            LibelleType = unLibelleType;
        }
    }
}
