using System;
using System.Collections.Generic;

namespace Preoff.Entity
{
    public partial class VGetTaskFromUser
    {
        public int Id { get; set; }
        public string TaskName { get; set; }
        public string TaskTypeName { get; set; }
        public DateTime? PubTime { get; set; }
        public DateTime? EndTime { get; set; }
        public string TaskDesc { get; set; }
        public string StateName { get; set; }
    }
}
