using System;
using System.Collections.Generic;

namespace Preoff.Entity
{
    public partial class TaskStateTable
    {
        public TaskStateTable()
        {
            TaskTable = new HashSet<TaskTable>();
        }

        public int Id { get; set; }
        public string StateName { get; set; }

        public ICollection<TaskTable> TaskTable { get; set; }
    }
}
