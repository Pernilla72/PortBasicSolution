using PortBasicManager.DailyFunctions;
using PortBasicManager.Entities;

namespace PortBasicManager
{
    public class DockingProcedure
    {
        private const int TotalSlots = 64;  // Antal platser i hamnen
        private bool[] berthSlots = new bool[TotalSlots];  // Array för att hålla reda på lediga/upptagna platser
        private PortBasicContext context;

        public DockingProcedure(PortBasicContext context)
        {
            this.context = context;  // Initiera port-instansen
        }

        //Metod för att placera båtar i hamnen, listan vesselsInPort innehåller båtar som redan ligger vid kaj
        public List<Vessel> DockVessels(List<Vessel> vesselsInPort, List<Vessel> newVessels)
        {
            List<Vessel> rejectedVessels = new List<Vessel>();

            foreach (var vessel in newVessels)
            {
                bool docked = TryDockVessel(vessel);

                if (docked)
                {
                    vesselsInPort.Add(vessel);  // Lägg till båten i hamnen om den dockades framgångsrikt
                    UpdateDatabaseWithDockedVessel(vessel);  // Uppdatera databasen och hamnplatserna
                }
                else
                {
                    // Lägg till båten i listan över avvisade båtar om den inte fick plats
                    rejectedVessels.Add(vessel);
                    var rejectedVessel = new RejectedVessel
                    {
                        VesselId = vessel.VesselId  // Vi sparar endast VesselId i den här tabellen
                    };
                    context.RejectedVessels.Add(rejectedVessel);
                    context.SaveChanges();  // Spara avvisade båtar till databasen
                }
            }
            return rejectedVessels;
        }


        // Metod för att uppdatera databasen när en båt har befunnits möjlig att docka
        private void UpdateDatabaseWithDockedVessel(Vessel vessel)
        {
            double requiredSlots = Math.Ceiling(vessel.VesselSize);

            for (int i = 0; i < TotalSlots; i++)
            {
                var berth = context.Ports.FirstOrDefault(b => b.SlotId == i && b.Occupancy < 1);

                if (berth != null)
                {
                    berth.Occupancy += (decimal)vessel.VesselSize;

                    if (berth.Occupancy >= 1)
                    {
                        berth.VesselId = vessel.VesselId;
                    }
                    context.SaveChanges();
                    break;
                }
            }
        }

        //Metod för att kolla efter tillräckligt med sammanhängande lediga platser för den båt som ankommer till hamnen
        private bool TryDockVessel(Vessel vessel)
        {
            double requiredSlots = Math.Ceiling(vessel.VesselSize);
            double availableSlots = 0;

            for (int i = 0; i < TotalSlots; i++)
            {
                availableSlots = 0;  // Nollställ för varje ny platskontroll

                for (int j = i; j < TotalSlots; j++)
                {
                    var berth = context.Ports.FirstOrDefault(b => b.SlotId == j && b.Occupancy < 1);

                    if (berth != null)
                    {
                        availableSlots += 1;
                    }
                    else
                    {
                        break;
                    }

                    if (availableSlots >= requiredSlots)  // Om vi har tillräckligt med sammanhängande platser
                    {
                        return true;  // Båten kan docka
                    }
                }
            }

            return false;  // Det fanns inga tillräckligt stora sammanhängande lediga platser
        }


    }
}

