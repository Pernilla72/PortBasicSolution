
using PortBasicManager.DailyFunctions;

namespace PortBasicManager
{
    public class Program
    {
        static void Main(string[] args)
        {
            // 2. Generera en lista av nya båtar som ankommer idag
            var dailyArrivals = new DailyArrivals();
            List<Vessel> DailyVessels = dailyArrivals.GenerateDailyArrivals(5);

            Console.WriteLine("Created vessels in main :");  //Skriver ut för att testa at det fungerar.
            foreach (var vessel in DailyVessels)
            {
                Console.WriteLine(vessel.ToString());
            }





        }
    }
}
