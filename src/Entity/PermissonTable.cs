using System;
using System.Collections.Generic;

namespace Preoff.Entity
{
    public partial class PermissonTable
    {
        public PermissonTable()
        {
            RolePermissionTable = new HashSet<RolePermissionTable>();
        }

        public int Id { get; set; }
        public int? PId { get; set; }
        public string PermissonName { get; set; }
        public string PermissonDesc { get; set; }
        public string PermissonUrl { get; set; }

        public ICollection<RolePermissionTable> RolePermissionTable { get; set; }
    }
}
