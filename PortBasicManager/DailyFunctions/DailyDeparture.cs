using PortBasicManager.Entities;
using System;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PortBasicManager.DailyFunctions
{
    public class DailyDepartures
    {
        private const int TotalSlots = 64;
        private PortBasicContext context;

        public DailyDepartures(PortBasicContext context)
        {
            this.context = context;
        }

        // Metod för att hantera avresor och uppdatera platser i hamnen
        public List<Vessel> DailyLayTimeCountDown(List<Vessel> vesselsInPort)
        {
            List<Vessel> departingVessels = new List<Vessel>();

            foreach (var vessel in vesselsInPort.ToList())
            {
                // Minska LayTime med 1 för varje båt
                vessel.LayTime--;

                if (vessel.LayTime <= 0)
                {
                    // Lägg till båten i listan över avresande båtar
                    departingVessels.Add(vessel);

                    // Hitta och frigör de platser som båten upptar
                    FreeDockedVessel(vessel);

                    vesselsInPort.Remove(vessel);

                    context.Vessels.Remove(vessel);
                    context.SaveChanges();
                }
            }
            return departingVessels;
        }

        // Metod för att frigöra de platser som en båt upptar
        private void FreeDockedVessel(Vessel vessel)
        {
            double requiredSlots = Math.Ceiling(vessel.VesselSize);

            for (int i = 0; i < TotalSlots; i++)
            {
                var berth = context.Ports.FirstOrDefault(b => b.VesselIdA == vessel.VesselId || b.VesselIdB == vessel.VesselId);

                if (berth != null)
                {
                    berth.Occupancy = 0;  // Frigör platsen
                    if (berth.VesselIdA == vessel.VesselId) berth.VesselIdA = null;
                    if (berth.VesselIdB == vessel.VesselId) berth.VesselIdB = null;

                    context.SaveChanges();
                }
            }

            Console.WriteLine($"Vessel {vessel.VesselType} with ID: {vessel.VesselId} has left the harbor.");
        }
    }
}
