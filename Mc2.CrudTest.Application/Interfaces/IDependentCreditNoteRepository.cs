using Mc2.CrudTest.Domain.Models.DependentCreditNotes;
using Mc2.CrudTest.Domain.Models.IndependentCreditNotes;
using System;

namespace Mc2.CrudTest.Application.Interfaces
{
    public interface IDependentCreditNoteRepository: IRepository<DependentCreditNote, Guid>
    {
    }
}
