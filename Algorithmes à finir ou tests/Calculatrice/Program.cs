namespace Calculatrice
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string calcul="";
            char[] tableauCalcul;
            char caractereTemporaire=' ';
            string opperande = "";
            string opperateur = "";
            List<string> listeOpperande= new List<string>();




            //DEBUT
            Console.WriteLine("Bonjour. Entrez un calcul.");
            calcul= Console.ReadLine();
            tableauCalcul=calcul.ToCharArray();
            Console.WriteLine(calcul);

            for (int i = 0;i<tableauCalcul.Length;i++)
            {
                caractereTemporaire = tableauCalcul[i];

                if (char.IsDigit(caractereTemporaire))
                {
                    opperande += caractereTemporaire;
                }
                else
                {

                    opperateur += caractereTemporaire;
                    listeOpperande.Add(opperande);
                    opperande= "";

                }
            }
            //ajoute la derniere oppérande à la fin du calcul penser à rajouter la condition si != de ( , ) et ²
            listeOpperande.Add(opperande);
            
            Console.WriteLine(opperande);
            Console.WriteLine(opperateur);
            for (int i = 0;i<listeOpperande.Count;i++)
            {
                Console.WriteLine(listeOpperande[i]);
            }


        }
    }
}
