namespace Test
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //VARIABLES
            int i = 0;
            string calcul = " ";
            char[] stockCalcul;

            //DEBUT
            Console.WriteLine("Entrez votre expression mathématique :");
            calcul = Console.ReadLine();
            stockCalcul = calcul.ToCharArray();

            imprime(stockCalcul, i);

            calcul = Console.ReadLine();


        }

        static void imprime(char[] tableauChar, int iterateur)
        {
            for (int iterateur = 0; iterateur < tableauChar.Length; iterateur++)
            {
                Console.WriteLine(tableauChar[iterateur]);
            }
        }
    }
}
