using System;
using System.Collections.Generic;

namespace Preoff.Entity
{
    public partial class TaskTable
    {
        public TaskTable()
        {
            ExecTaskTable = new HashSet<ExecTaskTable>();
            TaskUserTable = new HashSet<TaskUserTable>();
        }

        public int Id { get; set; }
        public string TaskName { get; set; }
        public int? TaskTypeTableId { get; set; }
        public int? UserTableId { get; set; }
        public DateTime? PubTime { get; set; }
        public DateTime? EndTime { get; set; }
        public string TaskDesc { get; set; }
        public int? TaskStateTableId { get; set; }

        public TaskStateTable TaskStateTable { get; set; }
        public TaskTypeTable TaskTypeTable { get; set; }
        public ICollection<ExecTaskTable> ExecTaskTable { get; set; }
        public ICollection<TaskUserTable> TaskUserTable { get; set; }
    }
}
