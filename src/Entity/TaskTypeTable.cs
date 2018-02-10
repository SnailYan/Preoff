using System;
using System.Collections.Generic;

namespace Preoff.Entity
{
    public partial class TaskTypeTable
    {
        public TaskTypeTable()
        {
            TaskTable = new HashSet<TaskTable>();
        }

        public int Id { get; set; }
        public string TaskTypeName { get; set; }

        public ICollection<TaskTable> TaskTable { get; set; }
    }
}
