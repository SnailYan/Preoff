using System;
using System.Collections.Generic;

namespace Preoff.Entity
{
    public partial class CameraFacTable
    {
        public CameraFacTable()
        {
            CameraTypeTable = new HashSet<CameraTypeTable>();
        }

        public int Id { get; set; }
        public string CameraFacName { get; set; }
        public string CameraFacAddr { get; set; }
        public string LinkMan { get; set; }
        public string Telephone { get; set; }

        public ICollection<CameraTypeTable> CameraTypeTable { get; set; }
    }
}
