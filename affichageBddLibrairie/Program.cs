using System.Data;
using System.Data.SqlClient;
using System.Security.Cryptography.X509Certificates;
using affichageBddLibrairie.Models;
using static affichageBddLibrairie.Fonctions.Fonctions;

namespace affichageBddLibrairie
{
    public class Program
    {
        public static void Main(string[] args)
        {

            //      CONNECTION A LA BASE DE DONNEES LIBRAIRIE   //
            //      CREATION DE REQUETE SQL                     //
            //      LECTURE DE RESULTAT DE LA REQUETE SQL       //

            
            //on instancie la classe SqlConnection sous le nom 'connexion' qui prend pour argument la ligne de connection  ->  ouverture de la connection.
            SqlConnection connexion = new SqlConnection(@"*****");
            connexion.Open();
            

            //on crée une variable 'RequestGetFromDB'de type SqlCommand de valeur connexion.CreateCommand()  ->  création de commande.
            SqlCommand RequestGetFromDB = connexion.CreateCommand();
            RequestGetFromDB.CommandText = "Select * from Auteur where IdAuteur=5";

            //on crée une variable 'resultat' RequestGetFromDB de type SqlDataReader de valeur RequestGetFromDB.ExecuteReader()  ->  lecture du résultat.
            SqlDataReader resultat = RequestGetFromDB.ExecuteReader();



            //cette fonction permet de consulter un auteur par son id entré par l'utilisateur. 
            rechercherAuteur();
             

            //Cette fonction affiche le résultat de la requête sql commandText
            /*
            afficheResultatColones(resultat);
            */


            //cette fonction crée une nouvelle instance de la classe 'Auteur' qui a pour attibut le résultat de la requête sql commandText.
            /*
            nouvelObjetResultatRequete(resultat);
            */


            //Cette fonction compare les nom et prénom de nouvelAuteur avec ceux des Auteurs de la base de données.
            /*
            comparer(resultat);
            */


            //cette fonction insere un nouvel auteur à la base de données depuis une nouvelle instance de la classe 'Auteur' définie en début de fonction.
            /*
            InsererAuteur();
            */


            demandeResultat();
            
            connexion.Close();
        }
        
        
        
    }
}
