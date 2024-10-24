using Microsoft.EntityFrameworkCore;
using PortBasicManager.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PortBasicManager.DailyFunctions
{
    public class DailyArrivals
    {
        private static Random random = new Random();
        private readonly PortBasicContext _context;

        public DailyArrivals(PortBasicContext context = null) // Injektionsberoende
        {
            _context = context;
        }


        #region Create vessles
        private RowBoat CreateRowboat()
        {
            return new RowBoat
            {
                WeightInKg = random.Next(100, 301),
                SpeedInKnots = random.Next(0, 4),
                VesselId = GenerateVesselId("R"),
                NumberOfPassengers = random.Next(1, 7)
            };
        }
        private MotorBoat CreateMotorboat()
        {
            return new MotorBoat
            {
                WeightInKg = random.Next(200, 3001),
                SpeedInKnots = random.Next(0, 61),
                VesselId = GenerateVesselId("M"),
                NumberOfHorsepower = random.Next(10, 1001)
            };
        }
        private SailBoat CreateSailboat()
        {
            return new SailBoat
            {
                WeightInKg = random.Next(500, 6001),
                SpeedInKnots = random.Next(0, 13),
                VesselId = GenerateVesselId("S"),
                LengthOfSailboat = random.Next(10, 61)
            };
        }
        private CargoShip CreateCargoShip()
        {
            return new CargoShip
            {
                WeightInKg = random.Next(3000, 20001),
                SpeedInKnots = random.Next(0, 21),
                VesselId = GenerateVesselId("L"),
                NumberOfContainers = random.Next(0, 501)
            };
        }
        #endregion

        public string GenerateVesselId(string VesselPrefix)
        {
            var randomNumber = random.Next(100, 999);  //Generera nummer mellan 100-998
            return $"{VesselPrefix}-{randomNumber}";
        }

        #region Generate daily Vessels
        public List<Vessel> GenerateDailyArrivals(int amount)   //amount för att kunna ndra antalet enkelt
        {
            List<Vessel> DailyVessels = new List<Vessel>();
            for (int i = 0; i < amount; i++)
            {
                Vessel vessel = CreateRandomVessel();  // Skapa en ny båt

                if (vessel != null)
                {
                    DailyVessels.Add(vessel);  // Lägg till båten i listan
                    _context.Vessels.Add(vessel);  // Lägg till båten i databasen
                }
            }

            _context.SaveChanges();  // Spara alla nya båtar till databasen

            return DailyVessels;
        }


        private Vessel CreateRandomVessel()
        {
            int VesselType = random.Next(1, 5);  // Slumpa en fartygstyp

            switch (VesselType)
            {
                case 1:
                    return CreateRowboat();
                case 2:
                    return CreateMotorboat();
                case 3:
                    return CreateSailboat();
                case 4:
                    return CreateCargoShip();
                default:
                    return null;
            }
        }
            #endregion
    

        public void DisplayArrivals()   //för att testa om min Create daily vessels fungerade.
        {
            DailyArrivals arrivals = new DailyArrivals();
            List<Vessel> vessels = arrivals.GenerateDailyArrivals(5);   //Antlaet båtar som är valt att genereras just nu.

            // Iterera över listan och skriv ut detaljer för varje båt
            foreach (var vessel in vessels)
            {
                Console.WriteLine($"Created from class DailyArrivals: {vessel.VesselType} - ID: {vessel.VesselId}, Weight: {vessel.WeightInKg}, Speed: {vessel.SpeedInKnots} knots");
            }
        }
    }
}   

