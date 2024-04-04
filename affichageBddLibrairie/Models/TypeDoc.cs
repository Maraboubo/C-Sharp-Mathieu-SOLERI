using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace affichageBddLibrairie.Models
{
    internal class TypeDoc
    {
        public int CodeType { get; set; }
        public string LibelleType { get; set; }

        public TypeDoc( int unCodeType, string unLibelleType )
        {
            CodeType = unCodeType;
            LibelleType = unLibelleType;
        }
    }
}
