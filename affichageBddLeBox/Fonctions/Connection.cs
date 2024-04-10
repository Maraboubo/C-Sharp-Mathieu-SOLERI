using System;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static affichageBddLeBox.Environment.Environment;

namespace affichageBddLeBox.Fonctions
{
    public class Connection
    {
        public static void Connexion() 
        {
            SqlConnection connexion = new SqlConnection(CleConnection());
            connexion.Open();
        }

        public static void Commande(SqlConnection connectionOuverte, string commande)
        {
            SqlCommand nouvelleCommande = connectionOuverte.CreateCommand();
            nouvelleCommande.CommandText = commande;
        }

        public static void lecture(SqlCommand laCommande)
        {
            SqlDataReader resultat= laCommande.ExecuteReader();
        }
    }
}
