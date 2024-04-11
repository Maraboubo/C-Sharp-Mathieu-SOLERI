using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace application_Musicale.Models
{
    internal class UTILISATEUR
    {
        /// <summary>
        /// UN IDENTIFIANT UTILISATEUR
        /// UN CODE VILLE
        /// UN NOM D'UTILISATEUR
        /// UN PRENOM D'UTILISATEUR
        /// UNE ADRESSE D'UTILISATEUR LIGNE 1
        /// UNE ADRESSE D'UTILISATEUR LIGNE 2
        /// UNE PHOTO D'UTILISATEUR
        /// </summary>
        public int id_utilisateur { get; set; }
        public int id_statut {  get; set; }
        public int id_vCode { get; set; }
        public string uNom { get; set; }
        public string uPrenom { get; set; }
        public string uIdentifiant { get; set; }
        public string uMotDePasse { get; set; }
        public string uAdresse1 { get; set; }
        public string? uAdresse2 { get; set; }
        public byte[]? uPhoto { get; set; }

        public UTILISATEUR(int unIdUtilisateur, int unIdStatut, int unIdVcode, string unUNom, string unUPrenom, string unUIdentifiant, string unUMotDePasse, string unUAdresse1, string? unUAdresse2, byte[]? unUPhoto ) 
        {
            id_utilisateur = unIdUtilisateur;
            id_statut = unIdStatut;
            id_vCode = unIdVcode;
            uNom = unUNom;
            uPrenom = unUPrenom;
            uIdentifiant=unUIdentifiant;
            uMotDePasse=unUMotDePasse;
            uAdresse1 = unUAdresse1;
            uAdresse2 = unUAdresse2;
            uPhoto = unUPhoto;
        }

    }
}
