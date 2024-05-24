﻿using System;
using System.Collections.Generic;

namespace DomainEntities.DBEntities
{
    public partial class Client
    {
        public Client()
        {
            AccountOpenings = new HashSet<AccountOpening>();
            Loans = new HashSet<Loan>();
        }

        public int Id { get; set; }
        public string FullName { get; set; } = null!;
        public string Mobile { get; set; } = null!;
        public DateTime? DateOfBirth { get; set; }
        public string? Address { get; set; }
        public DateTime RegisterDate { get; set; }
        public string NationalId { get; set; } = null!;
        public int? NationalityId { get; set; }
        public string? PassportNumber { get; set; }
        public string Email { get; set; } = null!;

        public virtual Nationality? Nationality { get; set; }
        public virtual ICollection<AccountOpening> AccountOpenings { get; set; }
        public virtual ICollection<Loan> Loans { get; set; }
    }
}
