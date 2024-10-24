
using PortBasicManager.DailyFunctions;
using PortBasicManager.Entities;

namespace PortBasicManager
{
    public class Program
    {
        static void Main(string[] args)
        {
            using (var context = new PortBasicContext())
            {
                List<Vessel> vesselsInPort = new List<Vessel>();
                // 2. Generera en lista av nya båtar som ankommer idag
                var dailyArrivals = new DailyArrivals(context);
                List<Vessel> DailyVessels = dailyArrivals.GenerateDailyArrivals(5);

                Console.WriteLine("Created vessels in main :");  //Skriver ut för att testa at det fungerar.
                foreach (var vessel in DailyVessels)
                {
                    Console.WriteLine(vessel.ToString());
                }
                // 3. Försök docka de nya båtarna i hamnen
                var dockingProcedure = new DockingProcedure(context);
                List<Vessel> rejectedVessels = dockingProcedure.DockVessels(vesselsInPort, DailyVessels);

                // Skriv ut resultatet till konsolen
                Console.WriteLine("Vessels at berth:");
                foreach (var vessel in vesselsInPort)
                {
                    Console.WriteLine($"{vessel.VesselType} with ID: {vessel.VesselId} securely at berth.");
                }

                Console.WriteLine("\nRejected vessels of the day:");
                foreach (var rejectedVessel in rejectedVessels)
                {
                    Console.WriteLine($"From Main, rejected vessels with ID: {rejectedVessel.VesselId} was rejected.");
                }

                context.SaveChanges();
            }
        }
    }
}
