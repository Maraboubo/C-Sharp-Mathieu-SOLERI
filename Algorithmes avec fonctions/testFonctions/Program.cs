using System.Security.Cryptography.X509Certificates;

namespace testFonctions
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //VARIABLES
            string cafe = "Je voudrais du café s'il vous plais.";
            string toto=Console.ReadLine();

            SP_affiche(cafe);
        }
        //FONCTIONS
        static void SP_affiche(string variable)
        {
            Console.WriteLine(variable);
        }
    }
}
