using System;
using System.Data;

class Program
{
    static void Main()
    {
        //VARIABLES
        int i = 0;
        string calcul = " ";
        char[] stockCalcul;
        int[] stockCalculInt;


        //DEBUT
        Console.WriteLine("Entrez votre expression mathématique :");
        calcul = Console.ReadLine();
        stockCalcul = calcul.ToCharArray();
        stockCalculInt = new int[stockCalcul.Length];

        imprime(stockCalcul, i, '0', stockCalculInt, 0);
        imprime(stockCalcul, i, '1', stockCalculInt, 1);
        imprime(stockCalcul, i, '2', stockCalculInt, 2);
        imprime(stockCalcul, i, '3', stockCalculInt, 3);
        imprime(stockCalcul, i, '4', stockCalculInt, 4);
        imprime(stockCalcul, i, '5', stockCalculInt, 5);
        imprime(stockCalcul, i, '6', stockCalculInt, 6);
        imprime(stockCalcul, i, '7', stockCalculInt, 7);
        imprime(stockCalcul, i, '8', stockCalculInt, 8);
        imprime(stockCalcul, i, '9', stockCalculInt, 9);
        imprime(stockCalcul, i, '+', stockCalculInt, +);


        calcul = Console.ReadLine();


    }

    static void imprime(char[] tableauChar, int iterateur, char valeur1, int[] tableauInt, int valeur2)
    {

        for (iterateur = 0; iterateur < tableauChar.Length; iterateur++)
        {
            // Console.WriteLine(tableauChar[iterateur]);

            if (tableauChar[iterateur] == valeur1)
            {
                tableauInt[iterateur] = valeur2;
            }

        }
        for (iterateur = 0; iterateur < tableauInt.Length; iterateur++)
        {
            Console.WriteLine(tableauInt[iterateur]);
        }
    }
}
