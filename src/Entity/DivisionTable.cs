using System;
using System.Collections.Generic;

namespace Preoff.Entity
{
    public partial class DivisionTable
    {
        public DivisionTable()
        {
            UnitTable = new HashSet<UnitTable>();
        }

        public string Id { get; set; }
        public string PId { get; set; }
        public string DivisionName { get; set; }

        public ICollection<UnitTable> UnitTable { get; set; }
    }
}
