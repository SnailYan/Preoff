using System;

namespace Preoff.Entity
{
    public partial class ExecTaskTable
    {
        public int Id { get; set; }
        public int? TaskTableId { get; set; }
        public int? UserTableId { get; set; }
        public int? AircTableId { get; set; }
        public DateTime? StartTime { get; set; }
        public DateTime? EndTime { get; set; }
        public int? TaskStateTableId { get; set; }
    }
}
