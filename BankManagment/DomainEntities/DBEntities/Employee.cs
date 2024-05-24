using System;
using System.Collections.Generic;

namespace DomainEntities.DBEntities
{
    public partial class Employee
    {
        public Employee()
        {
            RoleUsers = new HashSet<RoleUser>();
        }

        public int Id { get; set; }
        public string FullName { get; set; } = null!;
        public string Mobile { get; set; } = null!;
        public string Address { get; set; } = null!;
        public string Email { get; set; } = null!;
        public DateTime JoinDate { get; set; }
        public decimal Salary { get; set; }
        public int QualificationId { get; set; }
        public DateTime DateOfBirth { get; set; }

        public virtual Qualification Qualification { get; set; } = null!;
        public virtual ICollection<RoleUser> RoleUsers { get; set; }
    }
}
