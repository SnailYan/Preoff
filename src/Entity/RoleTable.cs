using System;
using System.Collections.Generic;

namespace Preoff.Entity
{
    public partial class RoleTable
    {
        public RoleTable()
        {
            RolePermissionTable = new HashSet<RolePermissionTable>();
            UserRoleTable = new HashSet<UserRoleTable>();
        }

        public int Id { get; set; }
        public string RoleName { get; set; }
        public string RoleDesc { get; set; }

        public ICollection<RolePermissionTable> RolePermissionTable { get; set; }
        public ICollection<UserRoleTable> UserRoleTable { get; set; }
    }
}
