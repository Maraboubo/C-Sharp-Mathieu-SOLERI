﻿using application_Musicale.Fonctions;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using static application_Musicale.Fonctions.Connection;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace application_Musicale.Repository
{
    internal class DbGROUPE
    {
        public static void CrudGroupe()
        {
            int choix;
            string start = "o";
            Console.WriteLine("bonjour. Veuillez entrer votre choix");
            while (start == "o")
            {
                Console.WriteLine("Appuyez sur 1 pour consulter les groupes ");
                Console.WriteLine("Appuyez sur 2 pour créer un nouveau groupe");
                Console.WriteLine("Appuyez sur 3 pour inserer un nouveau groupe(sur un créneau d'identifiant non occupé)");
                Console.WriteLine("Appuyez sur 4 pour modifier un groupe");
                Console.WriteLine("Appuyez sur 5 pour supprimer un groupe");
                choix = int.Parse(Console.ReadLine());
                if (choix == 1)
                {
                    GetAllGroupe();
                }
                
                if (choix == 2)
                {
                    CreateNewGroupe();
                }
                if (choix == 3)
                {
                    InsertNewGroupe();
                }
                if (choix == 4)
                {
                    UpdateGroupe();
                }
                if (choix == 5)
                {
                    DeleteGroupe();
                }
                
                Console.WriteLine("Voulez vous revenir au menu principal ?");
                Console.WriteLine("'OUI': Appuyez sur 'o' et validez avec 'Entrée'");
                Console.WriteLine("'NON': Appuyez sur n'importe quelle touche et validez avec 'Entrée'");
                start = Console.ReadLine();
            }
        }
        public static void GetAllGroupe()
        {
            SqlConnection nouvelleConnection = Connexion();
            string requete = "select * from GROUPE";
            SqlCommand nouvelleCommande = Commande(nouvelleConnection, requete);
            SqlDataReader nouvelleLecture = lecture(nouvelleCommande);

            while (nouvelleLecture.Read())
            {
                Console.WriteLine(nouvelleLecture[0]+" " + nouvelleLecture[1]+" " + nouvelleLecture[2]);
            }
            Connexion().Close();
        }
        
        public static void CreateNewGroupe()
        {
            string nomGroupe=" ";

            Console.WriteLine("Veuillez entrer le nom du groupe SVP");

            nomGroupe = Console.ReadLine();

            SqlConnection nouvelleConnection = Connexion();
            string requete = "INSERT INTO GROUPE VALUES ((select max(id_groupe) from GROUPE)+1, '" + nomGroupe + "'," + "GETDATE())";
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

        public static void InsertNewGroupe()
        {
            int idGroupe=0;
            string nomGroupe = " ";

            Console.WriteLine("Veuillez entrer un identifiant pour le groupe SVP");
            idGroupe = int.Parse(Console.ReadLine());

            Console.WriteLine("Veuillez entrer le nom du groupe SVP");
            nomGroupe = Console.ReadLine();

            SqlConnection nouvelleConnection = Connexion();
            string requete = "INSERT INTO GROUPE VALUES ('" + idGroupe + "', '" + nomGroupe + "'," + "GETDATE())";
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

        public static void UpdateGroupe()
        {
            int idGroupe;
            string nomGroupe=" ";

            Console.WriteLine( "Veuillez entrer le numéro d'identifiant du groupe que vous voulez modifier et validez avec la touche 'Entrée'." );
            idGroupe = int.Parse(Console.ReadLine());
            Console.WriteLine("Veuillez entrer le nouveau nom du groupe sélectionné et validez avec la touche 'Entrée'.");
            nomGroupe= Console.ReadLine();
            SqlConnection nouvelleConnection = Connexion();
            string requete = "UPDATE GROUPE SET gNom = '"+nomGroupe+ "' WHERE id_groupe='"+idGroupe+"'";
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
        public static void DeleteGroupe()
        {
            int idGroupe;

            Console.WriteLine("Veuillez entrer le numéro d'identifiant du groupe que vous voulez supprimer et validez avec la touche 'Entrée'.");
            idGroupe = int.Parse(Console.ReadLine());

            SqlConnection nouvelleConnection = Connexion();
            string requete = "DELETE FROM GROUPE WHERE id_groupe='" + idGroupe + "'";
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
