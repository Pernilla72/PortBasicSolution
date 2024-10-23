using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PortBasicManager
{
    public abstract class Vessel
    {
        public string? VesselId { get; set; }
        public string? VesselType { get; set; }

        public double VesselSize { get; set; }

        public double? WeightInKg { get; set; }

        public double? SpeedInKnots { get; set; }

        public int? LayTime { get; set; }

        public Port Port { get; set; }  // Navigation property to Port

        public abstract void GenerateVesselId();

        public override string ToString()
        {
            return $"{VesselType} - ID: {VesselId}, Weight: {WeightInKg} kg, Speed: {SpeedInKnots} knots, LayTime: {LayTime} days";
        }
    }
}
