namespace multiAlg
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //VARIABLES
            int n = 1;
            char space = ' ';

            //DEBUT
            Console.WriteLine("Tables de multiplication");
            while (n <= 10 && space == ' ')
            {
                afficherTableMultiplication(n);
                n++;

                attendreTouche();
                }
                if (n > 10)
                {
                    Console.WriteLine("Au revoir !");
                }
            }

            //FIN

            static void afficherTableMultiplication(int multiplicateur)
            {
                Console.WriteLine("Table des " + multiplicateur);
                for (int i = 1; i <=10; i++)
                {
                    Console.WriteLine(i + "X" + multiplicateur + "=" + (i * multiplicateur));
                }
            }

            static void attendreTouche()
            {
                Console.WriteLine("...On respire...Frappez la touche 'espace' et validez...");
                while (Console.ReadKey().Key != ConsoleKey.Spacebar) ;
            }
    }
}
