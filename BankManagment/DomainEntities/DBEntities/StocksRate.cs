using System;
using System.Collections.Generic;

namespace DomainEntities.DBEntities
{
    public partial class StocksRate
    {
        public int Id { get; set; }
        public int NationalityId { get; set; }
        public decimal Rate { get; set; }

        public virtual Nationality Nationality { get; set; } = null!;
    }
}
