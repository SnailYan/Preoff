using System;
using System.Collections.Generic;

namespace Preoff.Entity
{
    public partial class EquipFacTable
    {
        public EquipFacTable()
        {
            AirLoadTable = new HashSet<AirLoadTable>();
        }

        public int Id { get; set; }
        public string EquipFacName { get; set; }
        public string EquipFacAddr { get; set; }
        public string LinkMan { get; set; }
        public string Telephone { get; set; }

        public ICollection<AirLoadTable> AirLoadTable { get; set; }
    }
}
