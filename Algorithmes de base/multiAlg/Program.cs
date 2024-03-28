namespace multiAlg
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //VARIABLES
            int n = 1;
            int i = 1;
            char space = ' ';


            //DEBUT
            Console.WriteLine("Tables de multiplication");
            while (n <= 10 && space == ' ')
            {
                Console.WriteLine("Table des " + n);
                for (i = 1; i <= 10; i++)
                {
                    Console.WriteLine(i + " X " + n + " = " + (i * n));
                }
                n = n + 1;
                Console.WriteLine("...On respire...Freppez la touche 'espace' et validez...");
                ConsoleKeyInfo keyInfo = Console.ReadKey();
                if (keyInfo.Key == ConsoleKey.Spacebar)
                {
                    space = ' ';
                }
                else
                {
                    space = 'Z';
                    Console.WriteLine("Au revoir!!!");
                }
                    if (n > 10)
                {
                    Console.WriteLine("Au revoir !");
                }
            }
            //FIN
        }
    }
}
