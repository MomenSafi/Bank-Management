using System;
using System.Collections.Generic;

namespace DomainEntities.DBEntities
{
    public partial class RoleUser
    {
        public int Id { get; set; }
        public int RoleId { get; set; }
        public int EmployeeId { get; set; }

        public virtual Employee Employee { get; set; } = null!;
        public virtual Role Role { get; set; } = null!;
    }
}
