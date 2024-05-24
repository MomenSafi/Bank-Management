using System;
using System.Collections.Generic;

namespace DomainEntities.DBEntities
{
    public partial class AccountOpening
    {
        public int Id { get; set; }
        public int TypeId { get; set; }
        public DateTime OpeningDate { get; set; }
        public int ClientId { get; set; }
        public string Iban { get; set; } = null!;
        public string Currency { get; set; } = null!;
        public decimal Balance { get; set; }
        public bool Status { get; set; }

        public virtual Client Client { get; set; } = null!;
        public virtual AccountType Type { get; set; } = null!;
    }
}
