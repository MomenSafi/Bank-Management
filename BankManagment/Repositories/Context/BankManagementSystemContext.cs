using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using DomainEntities.DBEntities;

namespace DomainEntities
{
    public partial class BankManagementSystemContext : DbContext
    {
        public BankManagementSystemContext()
        {
        }

        public BankManagementSystemContext(DbContextOptions<BankManagementSystemContext> options)
            : base(options)
        {
        }

        public virtual DbSet<AccountOpening> AccountOpenings { get; set; } = null!;
        public virtual DbSet<AccountType> AccountTypes { get; set; } = null!;
        public virtual DbSet<Client> Clients { get; set; } = null!;
        public virtual DbSet<DailyTransaction> DailyTransactions { get; set; } = null!;
        public virtual DbSet<Employee> Employees { get; set; } = null!;
        public virtual DbSet<Loan> Loans { get; set; } = null!;
        public virtual DbSet<LoanPayment> LoanPayments { get; set; } = null!;
        public virtual DbSet<LoanType> LoanTypes { get; set; } = null!;
        public virtual DbSet<Nationality> Nationalities { get; set; } = null!;
        public virtual DbSet<Qualification> Qualifications { get; set; } = null!;
        public virtual DbSet<Role> Roles { get; set; } = null!;
        public virtual DbSet<RoleUser> RoleUsers { get; set; } = null!;
        public virtual DbSet<StocksRate> StocksRates { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=.;Database=BankManagementSystem;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AccountOpening>(entity =>
            {
                entity.ToTable("AccountOpening", "Services");

                entity.Property(e => e.Balance).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.Currency).HasMaxLength(5);

                entity.Property(e => e.Iban)
                    .HasMaxLength(30)
                    .HasColumnName("IBAN");

                entity.Property(e => e.OpeningDate).HasColumnType("date");

                entity.HasOne(d => d.Client)
                    .WithMany(p => p.AccountOpenings)
                    .HasForeignKey(d => d.ClientId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_AccountOpening_Clients");

                entity.HasOne(d => d.Type)
                    .WithMany(p => p.AccountOpenings)
                    .HasForeignKey(d => d.TypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_AccountOpening_AccountTypes");
            });

            modelBuilder.Entity<AccountType>(entity =>
            {
                entity.ToTable("AccountTypes", "Admin");

                entity.Property(e => e.Name).HasMaxLength(50);
            });

            modelBuilder.Entity<Client>(entity =>
            {
                entity.ToTable("Clients", "Admin");

                entity.Property(e => e.Address).HasMaxLength(100);

                entity.Property(e => e.DateOfBirth).HasColumnType("date");

                entity.Property(e => e.Email).HasMaxLength(30);

                entity.Property(e => e.FullName).HasMaxLength(100);

                entity.Property(e => e.Mobile)
                    .HasMaxLength(10)
                    .HasColumnName("mobile");

                entity.Property(e => e.NationalId).HasMaxLength(10);

                entity.Property(e => e.PassportNumber).HasMaxLength(10);

                entity.Property(e => e.RegisterDate).HasColumnType("datetime");

                entity.HasOne(d => d.Nationality)
                    .WithMany(p => p.Clients)
                    .HasForeignKey(d => d.NationalityId)
                    .HasConstraintName("FK_Clients_Nationality");
            });

            modelBuilder.Entity<DailyTransaction>(entity =>
            {
                entity.ToTable("DailyTransactions", "Services");
            });

            modelBuilder.Entity<Employee>(entity =>
            {
                entity.ToTable("Employees", "Admin");

                entity.Property(e => e.Address).HasMaxLength(100);

                entity.Property(e => e.DateOfBirth).HasColumnType("date");

                entity.Property(e => e.Email).HasMaxLength(30);

                entity.Property(e => e.FullName).HasMaxLength(100);

                entity.Property(e => e.JoinDate).HasColumnType("date");

                entity.Property(e => e.Mobile).HasMaxLength(10);

                entity.Property(e => e.Salary).HasColumnType("decimal(18, 2)");

                entity.HasOne(d => d.Qualification)
                    .WithMany(p => p.Employees)
                    .HasForeignKey(d => d.QualificationId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Employees_Qualifications");
            });

            modelBuilder.Entity<Loan>(entity =>
            {
                entity.ToTable("Loans", "Services");

                entity.Property(e => e.Amount).HasColumnType("decimal(18, 3)");

                entity.Property(e => e.Currency).HasMaxLength(10);

                entity.Property(e => e.EndDate).HasColumnType("date");

                entity.Property(e => e.InterestValue).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.SattelmentAmount).HasColumnType("decimal(18, 3)");

                entity.Property(e => e.StartDate).HasColumnType("date");

                entity.Property(e => e.TaxValue).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.TotalAmountWithInterest).HasColumnType("decimal(18, 3)");

                entity.HasOne(d => d.Client)
                    .WithMany(p => p.Loans)
                    .HasForeignKey(d => d.ClientId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Loans_Clients");

                entity.HasOne(d => d.Type)
                    .WithMany(p => p.Loans)
                    .HasForeignKey(d => d.TypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Loans_LoanTypes");
            });

            modelBuilder.Entity<LoanPayment>(entity =>
            {
                entity.ToTable("LoanPayments", "Services");
            });

            modelBuilder.Entity<LoanType>(entity =>
            {
                entity.ToTable("LoanTypes", "Admin");

                entity.Property(e => e.InterestValue).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.MaxLoan).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.Name).HasMaxLength(50);

                entity.Property(e => e.TaxValue).HasColumnType("decimal(18, 2)");
            });

            modelBuilder.Entity<Nationality>(entity =>
            {
                entity.ToTable("Nationality", "Admin");

                entity.Property(e => e.Name).HasMaxLength(75);
            });

            modelBuilder.Entity<Qualification>(entity =>
            {
                entity.ToTable("Qualifications", "Admin");

                entity.Property(e => e.Name).HasMaxLength(50);
            });

            modelBuilder.Entity<Role>(entity =>
            {
                entity.ToTable("Roles", "Admin");

                entity.Property(e => e.Name).HasMaxLength(50);
            });

            modelBuilder.Entity<RoleUser>(entity =>
            {
                entity.ToTable("RoleUsers", "Admin");

                entity.HasOne(d => d.Employee)
                    .WithMany(p => p.RoleUsers)
                    .HasForeignKey(d => d.EmployeeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_RoleUsers_Employees");

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.RoleUsers)
                    .HasForeignKey(d => d.RoleId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_RoleUsers_Roles");
            });

            modelBuilder.Entity<StocksRate>(entity =>
            {
                entity.ToTable("StocksRates", "Admin");

                entity.Property(e => e.Rate).HasColumnType("decimal(18, 3)");

                entity.HasOne(d => d.Nationality)
                    .WithMany(p => p.StocksRates)
                    .HasForeignKey(d => d.NationalityId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_StocksRates_Nationality");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
