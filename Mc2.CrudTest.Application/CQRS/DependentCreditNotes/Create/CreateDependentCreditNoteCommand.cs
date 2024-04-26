using Mc2.CrudTest.Domain.Dtos.Invoices;
using Mc2.CrudTest.Domain.Models.DependentCreditNotes;
using MediatR;
using ServiceResult;

namespace Mc2.CrudTest.Application.CQRS.DependentCreditNotes.Create
{
    public class CreateDependentCreditNoteCommand: IRequest<bool>
    {
        public DependentCreditNoteInputDto DependentCreditNoteInputDto { get; private set; }

        public CreateDependentCreditNoteCommand(DependentCreditNoteInputDto dependentCreditNoteInputDto)
        {
            DependentCreditNoteInputDto = dependentCreditNoteInputDto;
        }
    }
}
