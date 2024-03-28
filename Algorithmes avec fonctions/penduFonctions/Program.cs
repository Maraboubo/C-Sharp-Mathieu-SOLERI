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
            int i = 0;
            int bLettres = 0;
            int checkLettre = 0;

            //DEBUT

            afficherTexte("++Jeu du pendu++");
            afficherTexte("Entrez un mot");
            mDevine=saisie();
            mDevineAsChars = tableau(mDevine);
            mCache = new string('*', mDevine.Length);
            mCacheAsChars = tableau(mCache);
            afficherTexte("Vous avez droit à 10 essais");
            afficherTexte("Mot découvert" + mCache);
            while ((bLettres < mDevine.Length) & (essais <= 10))
            {
                afficherTexte("Entrez une lettre :");
                string lettre=saisie();
                lettreAsChars = tableau(lettre);
                essais++;
                for (i = 0; i < mDevine.Length; i++)
                {
                    if (mDevineAsChars[i] == lettreAsChars[0])
                    {
                        mCacheAsChars[i] = mDevineAsChars[i];
                        bLettres++;
                    }
                }
                if (checkLettre == bLettres)
                {
                    afficherTexte("Dommage....continuez quand même!!!");
                }
                else
                {
                    afficherTexte("Super continuez !!!!");

                }
                string mCacheAComparer = new string(mCacheAsChars);

                afficherTexte("Vous en êtes à ");

                checkLettre = bLettres;
                foreach (char caractere in mCacheAsChars)
                {
                    Console.Write(caractere);
                }
                if (mCacheAComparer.Equals(mDevine))
                {
                    afficherTexte("Bravo !!! vous avez gagné en " + essais + " éssais");
                }
            }
            if (essais >= 10)
            {
                afficherTexte("Dommage, le mot était :" + mDevine);

                afficherTexte("Vous avez trouvé " + bLettres + " bonnes lettres, vous ferez mieux la prochaine fois...");
            }
        }
        //FONCTIONS
        static void afficherTexte(string texte)
        {
            Console.WriteLine(texte);
        }

        static string saisie ()
        {
           string variable=Console.ReadLine();
           return variable;
        }

        static char[] tableau(string variable)
        {
            char[] table=variable.ToCharArray();
            return table;
        }
    }
}



