namespace Impair
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int i;
            int n = 1;
            
            //DEBUT
            Console.WriteLine("++ Algorithme lancé ++");
            for (i = 1; i <= 20; i++) 
            {
                Console.WriteLine(n + " est le " + i + " eme nombre impair");
                n = n + 2;
            }
            Console.WriteLine("++ Algorithme terminé ++");
        }
    }
}
