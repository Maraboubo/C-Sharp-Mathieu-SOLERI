namespace factorAlgFonctions
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //VARIABLES
            int i;
            int n;
            int resultat = 1;
            string start = "o";

            //DEBUT
            while (start == "o")
            {
               
                string titre = "Calcul de factorielle";
                affiche(titre);
                
                string entre = "Entrez un nombre";
                affiche(entre);

                n = Convert.ToInt32(Console.ReadLine());

                string entrePlusN = "Entrez un nombre : "+n;
                affiche(entrePlusN);

                calculFact(n, resultat);

                start = Console.ReadLine();
                affiche(start);
                n = 0;
            }
            //FIN
        }
        //FONCTIONS
        static void affiche(string message )
        { 
            Console.WriteLine( message ); 
        }

        static void calculFact(int nombre,/* int increment*/ int total)
        {
            if (nombre > 0)
            {
                int increment;
                for (increment = 1; increment <= nombre; increment++)
                {
                    total = total * increment;
                }
                string resultOk = "La factorielle de " + nombre + " est donc : " + total;
                affiche(resultOk);
            }
            else if (nombre == 0)
            {

                string resultZero = "La factorielle de 0 est : 1";
                affiche(resultZero);
            }
            else
            {
                string resultNeg = "Veuillez entrer un nombre positif";
                affiche(resultNeg);
            }
            string recom = "Voulez vous recommencer(o/n) ?";
            affiche(recom);
        }
    }
}
