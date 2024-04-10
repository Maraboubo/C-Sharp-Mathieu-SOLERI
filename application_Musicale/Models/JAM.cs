using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace application_Musicale.Models
{
    internal class JAM
    {
        /// <summary>
        /// ID POUR UNE JAM
        /// NOM DE LA JAM
        /// DATE DE CREATION DE LA JAM
        /// DATE DE DIFFUSION DE LA JAM
        /// DUREE DE LA JAM
        /// LIEN VERS LA DIFFUSION DE LA JAM
        /// </summary>
        public int id_jam { get; set; }
        public string jNom { get; set; }
        public DateTime jDateCrea { get; set; }
        public DateTime? jDateDif { get; set; }
        public TimeSpan? jDur { get; set; }
        public string? jLink {  get; set; }

        public JAM (int unid_jam, string unjNom, DateTime unjDateCrea, DateTime? unjDateDif, TimeSpan? unjDur, string? unjLink)
        {
            id_jam = unid_jam;
            jNom = unjNom;
            jDateCrea = unjDateCrea;
            jDateDif = unjDateDif;
            jDur = unjDur;
            jLink = unjLink;
        }
    }
}
