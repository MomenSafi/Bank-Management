using System;
using System.Collections.Generic;

namespace DomainEntities.DBEntities
{
    public partial class LoanType
    {
        public LoanType()
        {
            Loans = new HashSet<Loan>();
        }

        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public decimal? MaxLoan { get; set; }
        public decimal? InterestValue { get; set; }
        public decimal? TaxValue { get; set; }

        public virtual ICollection<Loan> Loans { get; set; }
    }
}
