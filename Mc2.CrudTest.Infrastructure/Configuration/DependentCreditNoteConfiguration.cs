using Mc2.CrudTest.Domain.Models.DependentCreditNotes;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace Mc2.CrudTest.Infrastructure.Configuration
{
    public class DependentCreditNoteConfiguration : IEntityTypeConfiguration<DependentCreditNote>
    {
        public void Configure(EntityTypeBuilder<DependentCreditNote> builder)
        {
            builder.ToTable("DependentCreditNotes");
            builder.HasKey(x => x.Id);
        }
    }
}
