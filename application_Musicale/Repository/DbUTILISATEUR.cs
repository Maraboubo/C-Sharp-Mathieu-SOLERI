using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using static application_Musicale.Fonctions.Connection;

namespace application_Musicale.Repository
{
    internal class DbUTILISATEUR
    {
        public static void CrudUtilisateurs()
        {
            int choix;
            string start = "o";
            Console.WriteLine("bonjour. Veuillez entrer votre choix");
            while (start == "o")
            {
                Console.WriteLine("Appuyez sur 1 pour consulter les utilisateurs ");
                Console.WriteLine("Appuyez sur 2 pour créer un nouvel utilisateur");
                Console.WriteLine("Appuyez sur 3 pour inserer un nouvel utilisateur (sur un créneau d'identifiant non occupé)");
                Console.WriteLine("Appuyez sur 4 pour modifier un utilisateur");
                Console.WriteLine("Appuyez sur 5 pour supprimer un utilisateurs");
                choix = int.Parse(Console.ReadLine());
                if (choix == 1)
                {
                    GetAllUtilisateurs();
                }
                /*
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
                */
                Console.WriteLine("Voulez vous revenir au menu principal ?");
                Console.WriteLine("'OUI': Appuyez sur 'o' et validez avec 'Entrée'");
                Console.WriteLine("'NON': Appuyez sur n'importe quelle touche et validez avec 'Entrée'");
                start = Console.ReadLine();
            }
        }
        public static void GetAllUtilisateurs()
        {
            SqlConnection nouvelleConnection = Connexion();
            string requete = 
                "SELECT uNom, uPrenom, uAdresse1, uAdresse2, vNom, pNom, iNom FROM UTILISATEUR\r\n" +
                "INNER JOIN VILLES\r\n" +
                "ON VILLES.id_vCode=UTILISATEUR.id_vCode\r\n" +
                "INNER JOIN PAYS\r\n" +
                "ON PAYS.id_pNom=VILLES.id_pNom\r\n" +
                "INNER JOIN INSTRUMENTS_UTILISATEUR\r\n" +
                "ON INSTRUMENTS_UTILISATEUR.id_utilisateur=UTILISATEUR.id_utilisateur\r\n" +
                "INNER JOIN INSTRUMENTS\r\n" +
                "ON INSTRUMENTS.id_instrument=INSTRUMENTS_UTILISATEUR.id_instrument";

            SqlCommand nouvelleCommande = Commande(nouvelleConnection, requete);
            SqlDataReader nouvelleLecture = lecture(nouvelleCommande);

            while (nouvelleLecture.Read())
            {
                Console.WriteLine
                    (
                    nouvelleLecture[0] +
                    " " + nouvelleLecture[1] + 
                    " " + nouvelleLecture[2] + 
                    " " + nouvelleLecture[3] + 
                    " " + nouvelleLecture[4] + 
                    " " + nouvelleLecture[5] + 
                    " " + nouvelleLecture[6]
                    );
            }
            Connexion().Close();
        }
    }
}

