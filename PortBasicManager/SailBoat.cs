using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PortBasicManager
{
    public class SailBoat : Vessel
    {
        public double LengthOfSailboat { get; set; }  // Unique feature
        public SailBoat()
        {
            VesselType = "Sailboat";
            VesselSize = 2;
            LayTime = 4;
            SpeedInKnots = 0;
        }
        public override void GenerateVesselId()
        {
            Random random = new Random();
            VesselId = "S-" + random.Next(100, 999);
        }
        public override string ToString()
        {
            return base.ToString() + $", Lenght of sailbot is {LengthOfSailboat} fot";
        }
    }
}
