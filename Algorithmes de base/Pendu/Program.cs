namespace Pendu
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //VARIABLES
            string mDevine = "";
            char[] mDevineAsChars;
            string lettre = "";
            char[] lettreAsChars;
            int essais = 0;
            string mCache;
            char[] mCacheAsChars;
            int i = 0;
            int bLettres = 0;
            int checkLettre = 0;

            //DEBUT
            Console.WriteLine("++Jeu du pendu++");

            Console.WriteLine("Entrez un mot");

            mDevine = Console.ReadLine();
            mDevineAsChars = mDevine.ToCharArray();

            mCache = new string('*', mDevine.Length);
            mCacheAsChars = mCache.ToCharArray();

            Console.WriteLine("Vous avez droit à 10 essais");
            Console.WriteLine("Mot découvert" + mCache);

            while ((bLettres < mDevine.Length) & (essais <= 10))
            {
                Console.WriteLine("Entrez une lettre :");
                lettre = Console.ReadLine();
                lettreAsChars = lettre.ToCharArray();
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
                    Console.WriteLine("Dommage....continuez quand même!!!");
                }
                else
                {
                    Console.WriteLine("Super continuez !!!!");
                }
                string mCacheAComparer = new string(mCacheAsChars);
                Console.WriteLine("Vous en êtes à ");
                checkLettre = bLettres;
                foreach (char caractere in mCacheAsChars)
                {
                    Console.Write(caractere);
                }
                if (mCacheAComparer.Equals(mDevine))
                {
                    Console.WriteLine("Bravo !!! vous avez gagné en " + essais + " éssais");
                }
            }
            if (essais >= 10)
            {
                Console.WriteLine("Dommage, le mot était :" + mDevine);
                Console.WriteLine("Vous avez trouvé " + bLettres + " bonnes lettres, vous ferez mieux la prochaine fois...");
            }
        }
    }
}
