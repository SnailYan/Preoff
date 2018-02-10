using System;
using System.Collections.Generic;

namespace Preoff.Entity
{
    public partial class ExecTaskTable
    {
        public ExecTaskTable()
        {
            EvevtTable = new HashSet<EvevtTable>();
        }

        public int Id { get; set; }
        public int? TaskTableId { get; set; }
        public int? UserTableId { get; set; }
        public int? AircTableId { get; set; }
        public DateTime? StartTime { get; set; }
        public DateTime? EndTime { get; set; }
        public int? TaskStateTableId { get; set; }

        public TaskTable TaskTable { get; set; }
        public ICollection<EvevtTable> EvevtTable { get; set; }
    }
}
