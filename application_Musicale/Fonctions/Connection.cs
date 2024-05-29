using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using static application_Musicale.Environment.Environment;

namespace application_Musicale.Fonctions
{
    public class Connection
    {
        public static SqlConnection Connexion()
        {
            SqlConnection connexion = new SqlConnection(CleConnection());
            connexion.Open();
            return connexion;
        }
        //public static SqlConnection Connexion()
        //{
        //    return new SqlConnection(CleConnection());
        //    //connexion.Open();
        //}

        public static SqlCommand Commande(SqlConnection connectionOuverte, string commande)
        {
            SqlCommand nouvelleCommande = connectionOuverte.CreateCommand();
            nouvelleCommande.CommandText = commande;
            return nouvelleCommande;
        }

        public static SqlDataReader lecture(SqlCommand laCommande)
        {
            SqlDataReader resultat = laCommande.ExecuteReader();
            return resultat;
        }
    }
}
