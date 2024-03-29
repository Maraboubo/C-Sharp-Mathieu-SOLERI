using System.Security.Cryptography.X509Certificates;

namespace penduFonctions
{
    internal class Program
    {
        static void Main(string[] args)
        {
            
            //VARIABLES
            string mDevine;
            char[] mDevineAsChars;
            char[] lettreAsChars;
            int essais = 0;
            string mCache;
            char[] mCacheAsChars;
            int i;
            int bLettres = 0;
            int checkLettre = 0;
            
            bool relance = true;

            //DEBUT
         
            while (relance == true)
            {
                Console.WriteLine(essais);
                essais = 0;
                Console.WriteLine(essais);
                Console.WriteLine(bLettres);
                bLettres= 0;
                Console.WriteLine(bLettres);
                Console.WriteLine(checkLettre);
                checkLettre = 0;
                Console.WriteLine(checkLettre);
                AfficherTexte("++Jeu du pendu++");
                AfficherTexte("Entrez un mot");
                mDevine = Saisie();
                mDevineAsChars = Tableau(mDevine);
                mCache = new string('*', mDevine.Length);
                mCacheAsChars = Tableau(mCache);
                AfficherTexte("Vous avez droit à 10 essais");
                AfficherTexte("Mot découvert" + mCache);

                while ((bLettres < Longueur(mDevine)) & (essais <= 10))
                {
                    AfficherTexte("Entrez une lettre :");
                    string lettre = Saisie();
                    lettreAsChars = Tableau(lettre);
                    essais++;
                    for (i = 0; i < Longueur(mDevine); i++)
                    {
                        if (mDevineAsChars[i] == lettreAsChars[0])
                        {
                            mCacheAsChars[i] = mDevineAsChars[i];
                            bLettres++;
                        }
                    }
                    if (checkLettre == bLettres)
                    {
                        AfficherTexte("Dommage....continuez quand même!!!");
                    }
                    else
                    {
                        AfficherTexte("Super continuez !!!!");
                    }
                    string mCacheAComparer = new string(mCacheAsChars);

                    AfficherTexte("Vous en êtes à ");

                    checkLettre = bLettres;

                    AfficheMotTrouve(mCacheAsChars);

                    if (mCacheAComparer.Equals(mDevine))
                    {
                        AfficherTexte("Bravo !!! vous avez gagné en " + essais + " éssais");
                    }
                }
                if (essais >= 10)
                {
                    AfficherTexte("Dommage, le mot était :" + mDevine);

                    AfficherTexte("Vous avez trouvé " + bLettres + " bonnes lettres, vous ferez mieux la prochaine fois...");
                }
                relance=Relancer();
            }
            
        }
        //FONCTIONS
        static void AfficherTexte(string texte)
        {
            Console.WriteLine(texte);
        }

        static string Saisie ()
        {
           string variable=Console.ReadLine();
           return variable;
        }

        static char[] Tableau(string variable)
        {
            char[] table=variable.ToCharArray();
            return table;
        }

        static int Longueur (string variable)
        {
            int taille=variable.Length;
            return taille;
        }

        static void AfficheMotTrouve(char[] variable)
        {
            Console.WriteLine("Appuyez sur 'espace' pour afficher le mot trouvé, autre touche pour passer");

            ConsoleKeyInfo keyInfo = Console.ReadKey();
            if (keyInfo.Key == ConsoleKey.Spacebar)
            {
                Console.WriteLine("Mot trouvé:" + new string(variable));
            }
        }
        static bool Relancer()
        {

            Console.WriteLine("Appuyez sur 'Entrée' pour relancer le jeu");
            ConsoleKeyInfo keyInfo = Console.ReadKey();

            if (keyInfo.Key == ConsoleKey.Enter)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

    }
}



