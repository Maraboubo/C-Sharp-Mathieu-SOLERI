using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace affichageBddLeBox.Models
{
    internal class Box
    {
        public int bNum {  get; set; }
        public int gNum { get; set; }
        public int lMont {  get; set; }
        public int lChar { get; set; }

        public Box(int unNuméroDeBox, int unNuméroDeGarage, int unMontantDeLoyer, int unMontantDeCharges ) 
        {
            int bNum = unNuméroDeBox;
            int gNum = unNuméroDeGarage;
            int lMont = unMontantDeLoyer;
            int lChar = unMontantDeCharges;
        }
    }
}
