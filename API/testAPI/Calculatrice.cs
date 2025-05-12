using Microsoft.AspNetCore.Mvc.Filters;

namespace TestApi
{
    public class Calculatrice
    {
        public int addition(int a, int b)
        {
            return a + b;
        }

        public int soustraction(int a, int b)
        {
            return a - b;
        }
    }
}
