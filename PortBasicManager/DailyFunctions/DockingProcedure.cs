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
            double requiredSlots = Math.Ceiling(vessel.VesselSize); // Motorboat should have 1 slot

            for (int i = 0; i < TotalSlots; i++)
            {
                var berth = context.Ports.FirstOrDefault(b => b.SlotId == i && b.Occupancy < 1);

                if (berth != null)
                {
                    // Kontrollera storleken på båten
                    if (vessel.VesselSize == 1)
                    {
                        berth.Occupancy = 1; // Sätt full upptagen för Motorboat
                        berth.VesselIdA = vessel.VesselId;  // Använd A-platsen
                        context.SaveChanges();
                        Console.WriteLine($"Motorboat docked in SlotId {berth.SlotId} with VesselId {vessel.VesselId}");
                        return; // Avsluta efter att ha dockat båten
                    }

                    // Hantera större båtar, t.ex. CargoShip som tar fler platser
                    if (requiredSlots > 1)
                    {
                        // Se till att ta rätt antal platser
                        for (int j = i; j < i + requiredSlots; j++)
                        {
                            var berthToUpdate = context.Ports.FirstOrDefault(b => b.SlotId == j);
                            if (berthToUpdate != null)
                            {
                                berthToUpdate.Occupancy = 1; // Markera plats som helt upptagen
                                berthToUpdate.VesselIdA = vessel.VesselId;  // Använd plats A
                            }
                        }
                        context.SaveChanges();
                        Console.WriteLine($"Vessel {vessel.VesselType} docked from SlotId {i} to {i + requiredSlots - 1} with VesselId {vessel.VesselId}");
                        return;
                    }
                }
            }
        }

        // Metod för att kolla efter tillräckligt med sammanhängande lediga platser för den båt som ankommer till hamnen
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
                        // Uppdatera platserna i hamnen
                        for (int k = i; k < i + requiredSlots; k++)
                        {
                            var berthToUpdate = context.Ports.FirstOrDefault(b => b.SlotId == k);

                            if (berthToUpdate != null)
                            {
                                // Om det är en roddbåt och platsen redan har en roddbåt, fyll i VesselIdB
                                if (vessel.VesselSize == 0.5 && berthToUpdate.Occupancy == 0.5m && berthToUpdate.VesselIdA != null && berthToUpdate.VesselIdB == null)
                                {
                                    berthToUpdate.Occupancy = 1.0m;  // Platsen är nu full
                                    berthToUpdate.VesselIdB = vessel.VesselId;  // Tilldela andra roddbåtens ID till VesselIdB
                                }
                                else
                                {
                                    // Annars tilldela första roddbåten eller en större båt
                                    berthToUpdate.Occupancy += (decimal)vessel.VesselSize;

                                    if (berthToUpdate.VesselIdA == null)
                                    {
                                        berthToUpdate.VesselIdA = vessel.VesselId;  // Tilldela båtens ID till VesselIdA om det är ledigt
                                    }
                                }
                            }
                        }

                        // Spara ändringar i databasen
                        context.SaveChanges();

                        // Skriv ut ett meddelande till konsolen när en båt har dockats
                        Console.WriteLine($"Vessel {vessel.VesselType} docked in SlotId {i} to {i + requiredSlots - 1} with VesselId {vessel.VesselId}");

                        return true;  // Dockning lyckades
                    }
                }
            }
            return false;  // Det fanns inga tillräckligt stora sammanhängande lediga platser
        }
    }
}

