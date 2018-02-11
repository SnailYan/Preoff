using System;
using System.Collections.Generic;

namespace Preoff.Entity
{
    public partial class TaskUserTable
    {
        public int Id { get; set; }
        public int? FlyTaskTableId { get; set; }
        public int? UserTableId { get; set; }
    }
}
