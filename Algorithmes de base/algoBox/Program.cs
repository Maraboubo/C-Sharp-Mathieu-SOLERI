namespace algoBox
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //VARIABLES
            int n=1;
            int somme=0;
            int compteur=0;
            int min=0;
            int max=0;
            //DEBUT

            Console.WriteLine("Calculs statistiques.");
            while(n!=0)
            {
                Console.WriteLine("Entrez un nombre (0 pour sortir)");
                n = Convert.ToInt32(Console.ReadLine());
                if (n != 0)
                {
                    compteur++;
                    somme = somme + n;
                    if (min == 0 || n < min)
                    {
                        min = n;
                    }
                    if (max == 0 || n > max)
                    {
                        max = n;
                    }
                }
                else
                {
                    Console.WriteLine(compteur + "nombres saisis");
                    Console.WriteLine("Compris entre" + min + " et " + max);
                    Console.WriteLine("Pour une somme de" + somme);
                    if (compteur == 0)
                    {
                        Console.WriteLine("Et une moyenne de 0");
                    }
                    else
                    {
                        Console.WriteLine("Et une moyenne de" + (somme / compteur));
                    }
                }
            }
            //FIN
        }
    }
}
