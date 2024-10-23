using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PortBasicManager
{
    public class CargoShip : Vessel
    {
        public int NumberOfContainers { get; set; }  // Unique feature
        public CargoShip()
        {
            VesselType = "Cargoship";
            VesselSize = 4;
            LayTime = 6;
            SpeedInKnots = 0;
            WeightInKg = 0;
        }
        public override void GenerateVesselId()
        {
            Random random = new Random();
            VesselId = "L-" + random.Next(100, 999);
        }
        public override string ToString()
        {
            return base.ToString() + $", Number of containers: {NumberOfContainers} pcs";
        }
    }
}
