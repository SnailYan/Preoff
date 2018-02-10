using System;
using System.Collections.Generic;

namespace Preoff.Entity
{
    public partial class UserRoleTable
    {
        public int Id { get; set; }
        public int? UserTableId { get; set; }
        public int? RoleTableId { get; set; }

        public RoleTable RoleTable { get; set; }
        public UserTable UserTable { get; set; }
    }
}
