using System;
using System.Collections.Generic;

namespace Preoff.Entity
{
    public partial class EvevtTable
    {
        public EvevtTable()
        {
            EventVideoTable = new HashSet<EventVideoTable>();
            EvevtImgTable = new HashSet<EvevtImgTable>();
        }

        public int Id { get; set; }
        public int? ExecTaskTableId { get; set; }
        public int? EventTypeTableId { get; set; }
        public double? PosX { get; set; }
        public double? PosY { get; set; }
        public double? PosZ { get; set; }
        public DateTime? EventTime { get; set; }
        public string EventDesc { get; set; }

        public EventTypeTable EventTypeTable { get; set; }
        public ExecTaskTable ExecTaskTable { get; set; }
        public ICollection<EventVideoTable> EventVideoTable { get; set; }
        public ICollection<EvevtImgTable> EvevtImgTable { get; set; }
    }
}
