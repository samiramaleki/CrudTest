using Mc2.CrudTest.Domain.Models.DependentCreditNotes;
using Mc2.CrudTest.Domain.Models.IndependentCreditNotes;
using Mc2.CrudTest.Domain.Models.Invoices;
using Mc2.CrudTest.Infrastructure.Configuration;
using Microsoft.EntityFrameworkCore;

namespace Mc2.CrudTest.Persistence.EF
{
    public class FinanceDbContext : DbContext
    {
        public FinanceDbContext()
        {

        }

        public FinanceDbContext(DbContextOptions<FinanceDbContext> options) : base(options)
        {

        }

        public DbSet<Invoice> Invoices { get; set; }
        public DbSet<DependentCreditNote> DependentCreditNotes { get; set; }
        public DbSet<IndependentCreditNote> IndependentCreditNotes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(InvoiceConfiguration).Assembly);
  
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
                optionsBuilder.UseSqlServer("Server=192.168.1.250,5003;Database=Mc2CrudTestD1;uid=sa;pwd=D9OUXpYkiWeOAZ9m21HU;");
        }
    }
}
