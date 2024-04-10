using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace application_Musicale.Models
{
    internal class PISTE
    {
        public int id_piste { get; set; }
        public int id_morceau { get; set; }
        public string pNom { get; set; }
        public byte[]? pImg { get; set; }

        public PISTE(int unIdPiste, int unIdMorceau, string unPNom, byte[]? unPImg) 
        {
            id_piste = unIdPiste;
            id_morceau = unIdMorceau;
            pNom = unPNom;
            pImg = unPImg;            
        }
    }
}
