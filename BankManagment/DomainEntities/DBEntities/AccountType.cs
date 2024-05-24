using System;
using System.Collections.Generic;

namespace DomainEntities.DBEntities
{
    public partial class AccountType
    {
        public AccountType()
        {
            AccountOpenings = new HashSet<AccountOpening>();
        }

        public int Id { get; set; }
        public string Name { get; set; } = null!;

        public virtual ICollection<AccountOpening> AccountOpenings { get; set; }
    }
}
