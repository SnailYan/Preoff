using System;
using System.Collections.Generic;

namespace Preoff.Entity
{
    public partial class AirLoadTable
    {
        public AirLoadTable()
        {
            AircTable = new HashSet<AircTable>();
        }

        public int Id { get; set; }
        public string EquipName { get; set; }
        public int? EquipFacTableId { get; set; }
        public string EquipDesc { get; set; }

        public EquipFacTable EquipFacTable { get; set; }
        public ICollection<AircTable> AircTable { get; set; }
    }
}
