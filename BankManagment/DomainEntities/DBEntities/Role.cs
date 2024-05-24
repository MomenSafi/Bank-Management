using System;
using System.Collections.Generic;

namespace DomainEntities.DBEntities
{
    public partial class Role
    {
        public Role()
        {
            RoleUsers = new HashSet<RoleUser>();
        }

        public int Id { get; set; }
        public string Name { get; set; } = null!;

        public virtual ICollection<RoleUser> RoleUsers { get; set; }
    }
}
