using NetBanking.Core.Domain.Common;
using NetBanking.Core.Domain.Entities;
using Microsoft.EntityFrameworkCore;


namespace NetBanking.Infrastructure.Persistence.Contexts
{
    public class ApplicationContext: DbContext
    {
        public ApplicationContext (DbContextOptions<ApplicationContext> options) : base(options) { }

        public DbSet<Beneficiary> Beneficiaries { get; set; }
        public DbSet<CreditCard> CreditCards { get; set; }
        public DbSet<Loan> Loans { get; set; }
        public DbSet<Payment> Payments { get; set; }
        public DbSet<SavingsAccount> SavingsAccounts { get; set; }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            foreach (var entry in ChangeTracker.Entries<AuditableBaseEntity>())
            {
                switch (entry.State)
                {
                    case EntityState.Added:
                        entry.Entity.Created = DateTime.Now;
                        entry.Entity.CreatedBy = "DefaultAppUser";
                        break;
                    case EntityState.Modified:
                        entry.Entity.LastModified = DateTime.Now;
                        entry.Entity.LastModifiedBy = "DefaultAppUser";
                        break;
                }
            }

            return base.SaveChangesAsync(cancellationToken);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            #region Tables
            modelBuilder.Entity<Beneficiary>()
                .ToTable("Beneficiaries");

            modelBuilder.Entity<CreditCard>()
                .ToTable("CreditCards");

            modelBuilder.Entity<Loan>()
                .ToTable("Loans");

            modelBuilder.Entity<Payment>()
                .ToTable("Payments");

            modelBuilder.Entity<SavingsAccount>()
                .ToTable("SavingsAccounts");
            #endregion

            #region Primary Keys
            modelBuilder.Entity<CreditCard>()
                .HasKey(c => c.Id);

            modelBuilder.Entity<Loan>()
                .HasKey(l => l.Id);

            modelBuilder.Entity<Payment>()
                .HasKey(p => p.Id);

            modelBuilder.Entity<SavingsAccount>()
                .HasKey(s => s.Id);

            modelBuilder.Entity<Beneficiary>()
                .HasKey(b => new {b.UserUserName,b.BeneficiaryUserName,b.AccountNumber});

            #endregion

            #region Relationships
            modelBuilder.Entity<SavingsAccount>()
                .HasMany<Payment>(s => s.Payments)
                .WithOne(p => p.FromAccount)
                .HasForeignKey(p => p.From)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<SavingsAccount>()
                .HasMany<Beneficiary>(s => s.Beneficiaries)
                .WithOne(b => b.SavingsAccount)
                .HasForeignKey(b => b.AccountNumber)
                .OnDelete(DeleteBehavior.NoAction);
            #endregion

            #region Property configurations

            #region CreditCard

            modelBuilder.Entity<CreditCard>(creditCard =>
            {
                creditCard.Property(c => c.Balance)
                .IsRequired();

                creditCard.Property(c => c.Limit)
                .IsRequired();

                creditCard.Property(c => c.CutoffDay)
                .IsRequired();

                creditCard.Property(c => c.PaymentDay)
                .IsRequired();

                creditCard.Property(c => c.ProductType)
                .IsRequired();
            });
            #endregion

            #region Loan
            modelBuilder.Entity<Loan>(loan =>
            {
                loan.Property(l => l.Balance)
                .IsRequired();

                loan.Property(l => l.InterestRate)
                .IsRequired();

                loan.Property(l => l.Installment)
                .IsRequired();

                loan.Property(l => l.PaymentDay)
                .IsRequired();

                loan.Property(l => l.ProductType)
                .IsRequired();
            });

            #endregion

            #region Payment
            modelBuilder.Entity<Payment>(payment =>
            {
                payment.Property(p => p.From)
                .IsRequired();

                payment.Property(p => p.To)
                .IsRequired();

                payment.Property(p => p.Amount)
                .IsRequired();

                payment.Property(p => p.Date)
                .IsRequired();

                payment.Property(p => p.Time)
                .IsRequired();
                payment.Property(p => p.Type)
                .IsRequired();
            });

            #endregion


            #region Savings Account
            modelBuilder.Entity<SavingsAccount>(savingsAcount =>
            {
                savingsAcount.Property(s => s.Balance)
                .IsRequired();

                savingsAcount.Property(s => s.IsPrincipal)
                .IsRequired();

                savingsAcount.Property(s => s.ProductType)
                .IsRequired();
            });

            #endregion


            #endregion
        }
    }
}
