using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PortBasicManager
{
    public class RowBoat : Vessel
    {
        public int NumberOfPassengers { get; set; }  // Unique feature
        public RowBoat()
        {
            VesselType = "Rowboat";
            VesselSize = 0.5;
            LayTime = 1;
            SpeedInKnots = 0;
            WeightInKg = 0;
        }
        public override void GenerateVesselId()
        {
            Random random = new Random();
            VesselId = "R-" + random.Next(100, 999);
        }
        public override string ToString()
        {
            return base.ToString() + $", Number of passengers: {NumberOfPassengers}";
        }
    }
}
