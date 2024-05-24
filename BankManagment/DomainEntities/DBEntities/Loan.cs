using System;
using System.Collections.Generic;

namespace DomainEntities.DBEntities
{
    public partial class Loan
    {
        public int Id { get; set; }
        public int TypeId { get; set; }
        public int ClientId { get; set; }
        public decimal Amount { get; set; }
        public int Period { get; set; }
        public decimal SattelmentAmount { get; set; }
        public decimal TotalAmountWithInterest { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public decimal InterestValue { get; set; }
        public decimal TaxValue { get; set; }
        public string Currency { get; set; } = null!;

        public virtual Client Client { get; set; } = null!;
        public virtual LoanType Type { get; set; } = null!;
    }
}
