
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


                // 1. Kör DailyDepartures först för att rensa bort båtar som ska lämna
                var dailyDepartures = new DailyDepartures(context);

                // Hämta alla båtar som ligger i hamnen
                List<Vessel> vesselsInPort = context.Vessels.ToList();

                // Skriv ut en lista på alla båtar innan nedräkningen
                Console.WriteLine("Vessels in port before countdown:");
                foreach (var vessel in vesselsInPort)
                {
                    Console.WriteLine($"{vessel.VesselType} with ID: {vessel.VesselId}, LayTime: {vessel.LayTime}");
                }

                    // Kör nedräkningslogiken
                    List<Vessel> departingVessels = dailyDepartures.DailyLayTimeCountDown(vesselsInPort);

                // Skriv ut resultat efter nedräkningen
                Console.WriteLine("\nVessels in port after countdown:");
                foreach (var vessel in vesselsInPort)
                {
                    Console.WriteLine($"{vessel.VesselType} with ID: {vessel.VesselId}, LayTime: {vessel.LayTime}");
                }

                // Skriv ut båtar som lämnat hamnen
                Console.WriteLine("\nVessels that have left the harbor:");
                foreach (var departingVessel in departingVessels)
                {
                    Console.WriteLine($"{departingVessel.VesselType} with ID: {departingVessel.VesselId} has departed.");
                }

                //2.Generera en lista av nya båtar som ankommer idag
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
