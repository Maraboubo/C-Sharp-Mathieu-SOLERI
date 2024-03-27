namespace majeur
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //variables
            int age;
            //début
            Console.WriteLine("Bienvenue entrez votre age");
            age = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine(age);
            if (age<18)
            {
                Console.WriteLine("Vous êtes mineur");
            }
            else
            {
                Console.WriteLine("Vous êtes majeur");
            }
        }
    }
}