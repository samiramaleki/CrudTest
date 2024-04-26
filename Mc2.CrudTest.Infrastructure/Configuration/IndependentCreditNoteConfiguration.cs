using Mc2.CrudTest.Domain.Models.IndependentCreditNotes;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace Mc2.CrudTest.Infrastructure.Configuration
{
    public class IndependentCreditNoteConfiguration : IEntityTypeConfiguration<IndependentCreditNote>
    {
        public void Configure(EntityTypeBuilder<IndependentCreditNote> builder)
        {
            builder.ToTable("IndependentCreditNote");
            builder.HasKey(prop => prop.Id);
        }
    }
}
