namespace Surface
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //VARIABLES
            int cote1 = 1;
            int cote2 = 39;
            int surfaceBase= 0;
            int surfaceMax = 0; 
            //DEBUT
            while (surfaceBase >= surfaceMax)
            {
                surfaceBase = (cote1*cote2);
                if(surfaceMax<surfaceBase)
                {
                    surfaceMax=surfaceBase;
                }
                cote1++;
                cote2 = (40 - cote1);
            }
            //FIN
        }
    }
}
