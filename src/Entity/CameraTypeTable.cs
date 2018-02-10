using System;
using System.Collections.Generic;

namespace Preoff.Entity
{
    public partial class CameraTypeTable
    {
        public CameraTypeTable()
        {
            CameraTable = new HashSet<CameraTable>();
        }

        public int Id { get; set; }
        public string CameraTypeName { get; set; }
        public int? CameraFacTableId { get; set; }

        public CameraFacTable CameraFacTable { get; set; }
        public ICollection<CameraTable> CameraTable { get; set; }
    }
}
