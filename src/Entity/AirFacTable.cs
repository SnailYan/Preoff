using System;
using System.Collections.Generic;

namespace Preoff.Entity
{
    public partial class AirFacTable
    {
        public AirFacTable()
        {
            AircTable = new HashSet<AircTable>();
            AircTypeTable = new HashSet<AircTypeTable>();
        }

        public int Id { get; set; }
        public string FacName { get; set; }
        public string FacAddr { get; set; }
        public string Telephone { get; set; }
        public string LinkMan { get; set; }

        public ICollection<AircTable> AircTable { get; set; }
        public ICollection<AircTypeTable> AircTypeTable { get; set; }
    }
}
