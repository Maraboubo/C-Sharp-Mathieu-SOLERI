using System;

namespace verificationAgeEtNouvelAge
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //VARIABLES

            string oui = "o";
            while (oui == "o")
            {
                int age = demanderAge();

                controleAge(age);

                oui=validationOui();

                finProgramme(oui);
            }          
        }
        //FONCTIONS

        static void finProgramme(string validation)
        {
            if (validation != "o")
            {
                Console.WriteLine("Fin du programme");
            }
        }

        static string validationOui()
        {
            Console.WriteLine("Entrez un nouvel age en appuyant sur 'o'");
            string oui = Console.ReadLine();
            return oui;
        }

        static int demanderAge()
        {
            Console.WriteLine("Bienvenue. Veillez entrer votre age ?");
            int age = Convert.ToInt32(Console.ReadLine());
            return age;
        }

        static void controleAge(int agePersonne)
        {
            if (agePersonne < 0)
            {
                agePersonne = agePersonne * (-1);
            }
            if (agePersonne < 18)
            {
                Console.WriteLine("Mineur");
            }
            else if (agePersonne < 25)
            {
                Console.WriteLine("Jeune adulte");
            }
            else if (agePersonne < 65)
            {
                Console.WriteLine("Adulte");
            }
            else if (agePersonne <150)
            {
                Console.WriteLine("Sénior");
            }
            else
            {
                Console.WriteLine("Veuillez entrer un age valide SVP...");
            }
        }
    }
}
