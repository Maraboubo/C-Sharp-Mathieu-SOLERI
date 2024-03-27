using System;
using System.Data;

class Program
{
    static void Main()
    {
        //VARIABLES
        string valid = "o";

        //DEBUT
        while (valid == "o")
        {
            Console.WriteLine("Entrez votre expression mathématique :");
            string expression = Console.ReadLine();

            for (int i = 0; i < expression.Length; i++)
            {
                if (expression[i] == 'x')
                {
                    expression = expression.Replace('x', '*');
                }
                else if (expression[i] == '÷')
                {
                    expression = expression.Replace('÷', '/');
                }
                else if (expression[i] == '^')
                {
                    int startIndex = i - 1;
                    int endIndex = i + 1;
                    while (startIndex >= 0 && char.IsDigit(expression[startIndex]))
                    {
                        startIndex--;
                    }
                    while (endIndex < expression.Length && char.IsDigit(expression[endIndex]))
                    {
                        endIndex++;
                    }
                    string baseValue = expression.Substring(startIndex + 1, i - startIndex - 1);
                    string exponentValue = expression.Substring(i + 1, endIndex - i - 1);
                    double baseNumber = double.Parse(baseValue);
                    double exponentNumber = double.Parse(exponentValue);
                    double result = Math.Pow(baseNumber, exponentNumber);
                    expression = expression.Replace(expression.Substring(startIndex + 1, endIndex - startIndex - 1), result.ToString());
                    i = startIndex + result.ToString().Length;

                }
            }

            try
            {
                object result = new DataTable().Compute(expression, null);
                Console.WriteLine("Résultat : " + result);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Une erreur s'est produite : " + ex.Message);
            }
            Console.WriteLine("appuyez sur la touche 'o' et validez avec 'entrée' pour Lancer un nouveau calcul");
            valid=Console.ReadLine();
        }
        //FIN
    }
}
