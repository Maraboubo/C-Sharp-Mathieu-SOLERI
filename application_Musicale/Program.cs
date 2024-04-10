using application_Musicale.Models;
using System.Data.SqlClient;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using static application_Musicale.Fonctions.Connection;
using static application_Musicale.Repository.DbGROUPE;


namespace application_Musicale
{
    internal static class Program
    {
        public static void Main(string[] args)
        {
            int choix;
            string start="o";
            Console.WriteLine( "bonjour. Veuillez entrer votre choix" );
            while (start == "o")
            {
                Console.WriteLine("Appuyez sur 1 pour consulter les groupes ");
                Console.WriteLine("Appuyez sur 2 pour créer un nouveau groupe");
                Console.WriteLine("Appuyez sur 3 pour modifier un groupe");
                Console.WriteLine("Appuyez sur 4 pour supprimer un groupe");
                choix = int.Parse(Console.ReadLine());
                if (choix == 1)
                {
                    GetAllGroupe();
                }
                if (choix == 2)
                {
                    CreateNewGroupe();
                }
                if(choix == 3)
                {
                    UpdateGroupe();
                }
                if(choix == 4)
                {
                    DeleteGroupe();
                }
                Console.WriteLine( "Voulez vous revenir au menu principal ?" );
                Console.WriteLine( "'OUI': Appuyez sur 'o' et validez avec 'Entrée'" );
                Console.WriteLine( "'NON': Appuyez sur n'importe quelle touche et validez avec 'Entrée'" );
                start=Console.ReadLine();
            }
        }
    }
}
