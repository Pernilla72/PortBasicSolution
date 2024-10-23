using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PortBasicManager
{
    public class MotorBoat : Vessel
    {
        public double NumberOfHorsepower { get; set; }  // Unique feature
        public MotorBoat()
        {
            VesselType = "Motorboat";
            VesselSize = 1;
            LayTime = 3;
            SpeedInKnots = 0;
            WeightInKg = 0;
        }
        public override void GenerateVesselId()
        {
            Random random = new Random();
            VesselId = "M-" + random.Next(100, 999);
        }
        public override string ToString()
        {
            return base.ToString() + $", Number of horsepowers: {NumberOfHorsepower} hp";
        }
    }
}
