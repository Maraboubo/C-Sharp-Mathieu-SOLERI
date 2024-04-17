using application_Musicale.Models;
using System.Data.SqlClient;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using static application_Musicale.Fonctions.Connection;
using static application_Musicale.Repository.DbGROUPE;
using static application_Musicale.Repository.DbALBUM;
using static application_Musicale.Repository.DbUTILISATEUR;


namespace application_Musicale
{
    internal static class Program
    {
        public static void Main(string[] args)
        {
            int choix;
            string start="o";
            Console.WriteLine("Bonjour. Bienvenue dans l'éditeur de la base de données de l'application musicale.");
            while (start == "o")
            {
                Console.WriteLine("Appuyez sur 1 pour acceder à la table 'GROUPE' ");
                Console.WriteLine("Appuyez sur 2 pour acceder à la table 'ALBUM' ");
                Console.WriteLine("Appuyez sur 3 pour acceder à la table 'UTILISATEURS' ");
                Console.WriteLine("Veuillez entrer votre choix et appuyez sur la touche 'Entrée' pour valider");

                choix = int.Parse(Console.ReadLine());
                if (choix == 1)
                {
                    CrudGroupe();
                }
                if (choix == 2)
                {
                    CrudAlbum();
                }
                if (choix == 3)
                {
                    CrudUtilisateurs();
                }

                Console.WriteLine("Voulez vous revenir au menu principal de l'éditeur de la base de données de l'application musicale.?");
                Console.WriteLine( "'OUI': Appuyez sur 'o' et validez avec 'Entrée'" );
                Console.WriteLine( "'NON': Appuyez sur n'importe quelle touche et validez avec 'Entrée'" );
                start=Console.ReadLine();
            }
        }
    }
}
