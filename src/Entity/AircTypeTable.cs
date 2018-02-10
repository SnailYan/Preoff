using System;
using System.Collections.Generic;

namespace Preoff.Entity
{
    public partial class AircTypeTable
    {
        public AircTypeTable()
        {
            AircTable = new HashSet<AircTable>();
        }

        public int Id { get; set; }
        public int? AirFacTableId { get; set; }

        public AirFacTable AirFacTable { get; set; }
        public ICollection<AircTable> AircTable { get; set; }
    }
}
