using System;

namespace factorAlg
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //VARIABLES
            int i;
            int n;
            int resultat=1;
            string start= "o";

            //DEBUT
            while (start=="o")
            {
                Console.WriteLine("Calcul de factorielle");
                Console.WriteLine("Entrez un nombre");
                n = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Entrer nNombre :" + n);
                if (n>0)
                {
                    for (i = 1; i <=n ; i++)
                    {
                        resultat = resultat * i;
                    }
                    Console.WriteLine("La factorielle de" + n + "est donc :" + resultat);
                }
                else if(n==0)
                {
                    Console.WriteLine("La factorielle de 0 est : 1");
                }
                else
                {
                    Console.WriteLine("Veuillez entrer un nombre positif");
                }
                Console.WriteLine("Voulez vous recommencer(o/n) ?");
                start = Console.ReadLine();
                Console.WriteLine(start);
                n = 0;
            }

            //FIN

        }
    }
}
