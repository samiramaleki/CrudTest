using MediatR;
using System;

namespace Mc2.CrudTest.Application.CQRS.DependentCreditNotes.Delete
{
    public class DeleteDependentCreditNoteCommand: IRequest<bool>
    {
        public Guid Id { get; set; }
    }
}
