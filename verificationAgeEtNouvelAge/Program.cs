using System;

namespace verificationAgeEtNouvelAge
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //VARIABLES
            int age;
            string oui = "o";
            while (oui=="o")
            {
                Console.WriteLine("Bienvenue. Veillez entrer votre age ?");
                age= Convert.ToInt32(Console.ReadLine());
                Console.WriteLine(age);
                if(age<0)
                {
                    age = age * (-1);
                }
                if (age<18)
                {
                    Console.WriteLine("Mineur");
                }
                else if (age<25)
                {
                    Console.WriteLine("Jeune adulte");
                }
                else if (age < 65)
                {
                    Console.WriteLine("Adulte");
                }
                else
                {
                    Console.WriteLine("Sénior");
                }
                Console.WriteLine("Entrez un nouvel age en appuyant sur 'o'");
                oui = Console.ReadLine();
                Console.WriteLine(oui);
                if (oui != "o")
                {
                    Console.WriteLine("Fin du programme");
                }
            }
        }
    }
}
