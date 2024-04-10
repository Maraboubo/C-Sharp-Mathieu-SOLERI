using affichageBddLeBox.Models;
using static affichageBddLeBox.Environment.Environment;

namespace affichageBddLeBox
{
    internal class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine(CleConnection());
            Console.ReadLine();
        }
    }
}
