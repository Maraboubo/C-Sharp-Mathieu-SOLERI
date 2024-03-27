namespace verificationAge
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //VARIABLES
            int age;
            //DEBUT
            Console.WriteLine("Bienvenue, veuillez entrer votre age ?");
            age = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine(age);
            // CONDITIONS
            if (age < 0 | age > 150)
            {
                Console.WriteLine("Age non valide !!!");
            }
            else if (age >= 0 & age <18)
            {
                Console.WriteLine("Jeune adulte");
            }
            else if (age >= 18 & age <= 25)
            {
                Console.WriteLine("Jeune adulte");
            }
            else if (age > 25 & age <= 65)
            {
                Console.WriteLine("Adulte");
            }
            else if(age>65 & age<=150)
            {
                Console.WriteLine("Sénior");
            }
            //FIN
        }
    }
}
