using Mc2.CrudTest.Domain.Models.Invoices;
using Microsoft.EntityFrameworkCore;

namespace Mc2.CrudTest.Infrastructure.Configuration
{
    public class InvoiceConfiguration : IEntityTypeConfiguration<Invoice>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Invoice> builder)
        {
            builder.ToTable("Invoices");
            builder.HasKey(prop => prop.Id);
            builder.HasMany(c => c.DependentCreditNotes).WithOne(c => c.Invoice).HasForeignKey(c => c.InvoiceId).OnDelete(DeleteBehavior.Cascade); ;
        }
    }
}
