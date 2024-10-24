using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PortBasicManager
{
    public class RejectedVessel
    {
        public int Id { get; set; }  // Primärnyckel
        public string VesselId { get; set; } = null!;  // ID för avvisad båt
    }
}
