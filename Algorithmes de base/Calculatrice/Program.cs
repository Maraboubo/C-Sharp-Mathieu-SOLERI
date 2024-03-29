using System;
using System.Data;

class Program
{
    static void Main()
    {
        //VARIABLES
        string calcul=" ";
        char[] stockCalcul;

        //DEBUT
        Console.WriteLine("Entrez votre expression mathématique :");
        calcul = Console.ReadLine();
        stockCalcul = calcul.ToCharArray();
        
            imprime(stockCalcul);

        calcul = Console.ReadLine();


    }

    static void imprime(char[] tableauChar, int i)
    {
        for (int i = 0; i < stockCalcul.Length; i++)
        {
            Console.WriteLine(tableauChar[i]);
        }
            
    }
}
