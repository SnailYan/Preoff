using System;
using System.Collections.Generic;

namespace Preoff.Entity
{
    public partial class EvevtImgTable
    {
        public int Id { get; set; }
        public int? EventTableId { get; set; }
        public string ImgPath { get; set; }
    }
}
