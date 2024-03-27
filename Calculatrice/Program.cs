uusing System;
using System.Data;

class Program
{
    static void Main()
    {
        Console.WriteLine("Entrez votre expression mathématique :");
        string expression = Console.ReadLine();

        try
        {
            object result = new DataTable().Compute(expression, null);
            Console.WriteLine("Résultat : " + result);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Une erreur s'est produite : " + ex.Message);
        }
    }
}
