using System;
using System.Buffers.Binary;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace application_Musicale.Models
{
    internal class ALBUM
    {
        /// <summary>
        /// IDENTIFIANT POUR L'ALBUM
        /// NOM DE L'ALBUM
        /// IMAGE/ILLUSTRATION DE L'ALBUM
        /// </summary>
        public int id_album {  get; set; }
        public string aNom {  get; set; }
        public byte[]? aImg { get; set; }

        public ALBUM(int unIdAlbum, string unNomAlbum, byte[]? uneImageAlbum)
        {
            id_album = unIdAlbum;
            aNom = unNomAlbum;
            aImg = uneImageAlbum;
        }
    }
}
