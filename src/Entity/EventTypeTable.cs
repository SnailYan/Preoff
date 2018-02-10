using System;
using System.Collections.Generic;

namespace Preoff.Entity
{
    public partial class EventTypeTable
    {
        public EventTypeTable()
        {
            EvevtTable = new HashSet<EvevtTable>();
        }

        public int Id { get; set; }
        public string EventName { get; set; }
        public string EventDesc { get; set; }

        public ICollection<EvevtTable> EvevtTable { get; set; }
    }
}
