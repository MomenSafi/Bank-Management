using System;
using System.Collections.Generic;

namespace DomainEntities.DBEntities
{
    public partial class Nationality
    {
        public Nationality()
        {
            Clients = new HashSet<Client>();
            StocksRates = new HashSet<StocksRate>();
        }

        public int Id { get; set; }
        public string Name { get; set; } = null!;

        public virtual ICollection<Client> Clients { get; set; }
        public virtual ICollection<StocksRate> StocksRates { get; set; }
    }
}
