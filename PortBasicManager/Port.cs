using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PortBasicManager
{
    public partial class Port
    {
        public int Id { get; set; }

        public int SlotId { get; set; }

        public decimal? Occupancy { get; set; }

        public string? VesselId { get; set; }

        public int? FreeSlots { get; set; }

        public ICollection<Vessel> Vessel { get; set; }  // Navigation property to Vessels
    }
}
