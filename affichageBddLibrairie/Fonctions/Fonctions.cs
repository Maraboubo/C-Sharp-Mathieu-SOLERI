using affichageBddLibrairie.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace affichageBddLibrairie.Fonctions
{
    public class Fonctions
    {

        //affiche les résultats pour chaque colones
        public static void afficheResultatColones(SqlDataReader produit)
        {
            while (produit.Read())
            {
                Console.WriteLine(produit[1] + " " + produit[2]);
            }
        }

    //insere un nouvel auteur
    public static void InsererAuteur()
        {
            int identifiant;
            string nomFamille;
            string prenomNouveau;

            Console.WriteLine("++Bonjour. Veuillez entrer l'identifiant du nouvel Auteur++");
            identifiant = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Veuillez entrer le nom de famille du nouvel Auteur++");
            nomFamille= Console.ReadLine();
            Console.WriteLine("Veuillez entrer le prénom du nouvel Auteur++");
            prenomNouveau = Console.ReadLine();

            Auteur nouvelAuteur = new Auteur(identifiant, nomFamille, prenomNouveau);

            string connectionString = @"***";
            string query = "INSERT INTO Auteur (NomAuteur, PrenomAuteur) VALUES (@Nom, @Prenom)";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                //command.Parameters.AddWithValue("@Id", nouvelAuteur.IdAuteur);
                command.Parameters.AddWithValue("@Nom", nouvelAuteur.NomAuteur);
                command.Parameters.AddWithValue("@Prenom", nouvelAuteur.PrenomAuteur);

                try
                {
                    connection.Open();
                    int rowsAffected = command.ExecuteNonQuery();
                    Console.WriteLine($"Nombre de lignes affectées : {rowsAffected}");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Une erreur s'est produite : {ex.Message}");
                }
                connection.Close();
            }
        }

        //Demander de satisfaction du résultat
        public static void demandeResultat()
        {
            Console.WriteLine("Êtes vous satifaits du résultat ?");
            string avis = Console.ReadLine();
            if (avis == "oui")
            {
                Console.WriteLine("Super !!");
            }
            else
            {
                Console.WriteLine("Pas de soucis recommence !!");
            }
        }

        //Cée une nouvelle instance de la classe Auteur.
        public static void nouvelAuteur()
        {
            //Creer un nouvel auteur
            Auteur nouvelAuteur = new Auteur(6, "Muddy", "Waters");
            //Afficher l'id, le nom et le prénom du nouvel auteur
            Console.WriteLine(nouvelAuteur.IdAuteur + " " + nouvelAuteur.NomAuteur + " " + nouvelAuteur.PrenomAuteur);
        }

        public static void nouvelObjetResultatRequete(SqlDataReader produit)
        {
            //crée un nouvel objet 'Auteur' qui a pour attibutle résultat de la requête sql commandText.
            while (produit.Read())
            {
                Auteur auteurResultat = new Auteur(produit.GetInt16(0), produit.GetString(1), produit.GetString(2));

                Console.WriteLine(auteurResultat.IdAuteur + " " + auteurResultat.NomAuteur + " " + auteurResultat.PrenomAuteur);
            }
        }

        public  static void comparer(SqlDataReader produit)
        {
            //compare les nom et prénom de nouvelAuteur avec ceux des Auteurs de la base de données.
            while (produit.Read())
            {
                Auteur nouvelAuteur = new Auteur(6, "Muddy", "Waters");
                Console.WriteLine(produit[1] + " " + produit[2]);

                //verifier les doublons
                if (produit[1].ToString() == nouvelAuteur.NomAuteur && produit[2].ToString() == nouvelAuteur.PrenomAuteur)
                {
                    Console.WriteLine("Désolé, le nom entré existe déjà");
                }
                else
                {
                    Console.WriteLine("Ok ça va !");
                }
            }
        }

        public static void rechercherAuteur()
        {
            //consulter un auteur par son id


            int identifiant;

            Console.WriteLine("++Bonjour. Veuillez entrer l'identifiant de l'auteur recherché++");
            identifiant = Convert.ToInt32(Console.ReadLine());

            string connectionString = @"*****";
            string query = "select * from Auteur where IdAuteur= @Id ";
            
            SqlConnection connection = new SqlConnection(connectionString);
            //-> la connexion est ouverte
            //connection.Open();
            

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@Id", identifiant);

            connection.Open();

            SqlDataReader produit = command.ExecuteReader();

            while (produit.Read())
            {
                Console.WriteLine(produit[1] + " " + produit[2]);
            }

            connection.Close();
        }

    }
}
