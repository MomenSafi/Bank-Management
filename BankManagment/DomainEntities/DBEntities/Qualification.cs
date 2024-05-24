using System;
using System.Collections.Generic;

namespace DomainEntities.DBEntities
{
    public partial class Qualification
    {
        public Qualification()
        {
            Employees = new HashSet<Employee>();
        }

        public int Id { get; set; }
        public string Name { get; set; } = null!;

        public virtual ICollection<Employee> Employees { get; set; }
    }
}
