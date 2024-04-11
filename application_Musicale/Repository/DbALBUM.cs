using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using static application_Musicale.Fonctions.Connection;

namespace application_Musicale.Repository
{
    internal class DbALBUM
    {
        public static void CrudAlbum()
        {
            int choix;
            string start = "o";
            Console.WriteLine("bonjour. Veuillez entrer votre choix");
            while (start == "o")
            {
                Console.WriteLine("Appuyez sur 1 pour consulter les Albums ");
                Console.WriteLine("Appuyez sur 2 pour créer un nouvel Album");
                Console.WriteLine("Appuyez sur 3 pour inserer un nouvel Album (sur un créneau d'identifiant non occupé)");
                Console.WriteLine("Appuyez sur 4 pour modifier un Album");
                Console.WriteLine("Appuyez sur 5 pour supprimer un Album");
                choix = int.Parse(Console.ReadLine());
                if (choix == 1)
                {
                    GetAllAlbums();
                }
                if (choix == 2)
                {
                    CreateNewAlbum();
                }
                if (choix == 3)
                {
                    InsertNewAlbum();
                }
                if (choix == 4)
                {
                    UpdateAlbum();
                }
                if (choix == 5)
                {
                    DeleteAlbum();
                }
                Console.WriteLine("Voulez vous revenir au menu principal ?");
                Console.WriteLine("'OUI': Appuyez sur 'o' et validez avec 'Entrée'");
                Console.WriteLine("'NON': Appuyez sur n'importe quelle touche et validez avec 'Entrée'");
                start = Console.ReadLine();
            }
        }
        
        public static void GetAllAlbums()
        {
            SqlConnection nouvelleConnection = Connexion();
            string requete = "select * from ALBUM";
            SqlCommand nouvelleCommande = Commande(nouvelleConnection, requete);
            SqlDataReader nouvelleLecture = lecture(nouvelleCommande);

            while (nouvelleLecture.Read())
            {
                Console.WriteLine(nouvelleLecture[0] + " " + nouvelleLecture[1] + " " + nouvelleLecture[2]);
            }
            Connexion().Close();
        }
        /// <summary>
        /// CETTE FONCTION PERMET DE CREER UN NOUVEL ALBUM EN INCREMENTANT D'UN LA VALEUR DE L'ID MAX
        /// POUR L'INSTANT ON INSERE QUE DES VALEURS D'IMAGES NULLES CAR ON AFFICHE UNIQUEMENT SUR CONSOLE
        /// </summary>
        public static void CreateNewAlbum()
        {
            string nomAlbum = " ";

            Console.WriteLine("Veuillez entrer le nom de l'Album SVP");

            nomAlbum = Console.ReadLine();

            SqlConnection nouvelleConnection = Connexion();
            string requete = "INSERT INTO ALBUM VALUES ((select max(id_album) from ALBUM)+1, '" + nomAlbum + "'," + "NULL)";
            SqlCommand nouvelleCommande = Commande(nouvelleConnection, requete);

            try
            {
                int rowsAffected = nouvelleCommande.ExecuteNonQuery();
                Console.WriteLine($"Nombre de lignes affectées : {rowsAffected}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Une erreur s'est produite : {ex.Message}");
            }
            Connexion().Close();
        }
        
        public static void InsertNewAlbum()
        {
            int idAlbum = 0;
            string nomAlbum = " ";

            Console.WriteLine("Veuillez entrer un identifiant pour l'Album SVP");
            idAlbum = int.Parse(Console.ReadLine());

            Console.WriteLine("Veuillez entrer un nom pour l'album SVP");
            nomAlbum = Console.ReadLine();

            SqlConnection nouvelleConnection = Connexion();
            string requete = "INSERT INTO ALBUM VALUES ('" + idAlbum + "', '" + nomAlbum + "'," + "NULL)";
            SqlCommand nouvelleCommande = Commande(nouvelleConnection, requete);

            try
            {
                int rowsAffected = nouvelleCommande.ExecuteNonQuery();
                Console.WriteLine($"Nombre de lignes affectées : {rowsAffected}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Une erreur s'est produite : {ex.Message}");
            }
            Connexion().Close();
        }
        
        public static void UpdateAlbum()
        {
            int idAlbum;
            string nomAlbum = " ";

            Console.WriteLine("Veuillez entrer le numéro d'identifiant de l'Album que vous voulez modifier et validez avec la touche 'Entrée'.");
            idAlbum = int.Parse(Console.ReadLine());
            Console.WriteLine("Veuillez entrer le nouveau nom de l'album sélectionné et validez avec la touche 'Entrée'.");
            nomAlbum = Console.ReadLine();
            SqlConnection nouvelleConnection = Connexion();
            string requete = "UPDATE ALBUM SET aNom = '" + nomAlbum + "' WHERE id_album='" + idAlbum + "'";
            SqlCommand nouvelleCommande = Commande(nouvelleConnection, requete);

            try
            {
                int rowsAffected = nouvelleCommande.ExecuteNonQuery();
                Console.WriteLine($"Nombre de lignes affectées : {rowsAffected}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Une erreur s'est produite : {ex.Message}");
            }
            Connexion().Close();
        }
        
        public static void DeleteAlbum()
        {
            int idAlbum;

            Console.WriteLine("Veuillez entrer le numéro d'identifiant de l'album que vous voulez supprimer et validez avec la touche 'Entrée'.");
            idAlbum = int.Parse(Console.ReadLine());

            SqlConnection nouvelleConnection = Connexion();
            string requete = "DELETE FROM ALBUM WHERE id_album='" + idAlbum + "'";
            SqlCommand nouvelleCommande = Commande(nouvelleConnection, requete);

            try
            {
                int rowsAffected = nouvelleCommande.ExecuteNonQuery();
                Console.WriteLine($"Nombre de lignes affectées : {rowsAffected}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Une erreur s'est produite : {ex.Message}");
            }
            Connexion().Close();
        }
    }
}
