using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace affichageBddLibrairie.Models
{
    internal class CommandeDoc
    {
        public int NumCo { get; set; }
        public int DocRef { get; set; }

        public CommandeDoc(int unNumCo, int uneRefDoc) 
        {
            NumCo = unNumCo;
            DocRef = uneRefDoc;
        }
    }
}
