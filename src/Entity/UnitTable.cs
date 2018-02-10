using System;
using System.Collections.Generic;

namespace Preoff.Entity
{
    public partial class UnitTable
    {
        public UnitTable()
        {
            AircTable = new HashSet<AircTable>();
            CameraTable = new HashSet<CameraTable>();
            UserTable = new HashSet<UserTable>();
        }

        public int Id { get; set; }
        public string UnitName { get; set; }
        public string DivisionTableId { get; set; }
        public string UnitAddr { get; set; }
        public string UnitPhone { get; set; }
        public string UnitDesc { get; set; }
        public int? StreamVideoServerTableId { get; set; }

        public DivisionTable DivisionTable { get; set; }
        public StreamVideoServerTable StreamVideoServerTable { get; set; }
        public ICollection<AircTable> AircTable { get; set; }
        public ICollection<CameraTable> CameraTable { get; set; }
        public ICollection<UserTable> UserTable { get; set; }
    }
}
