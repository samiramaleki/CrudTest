using Mc2.CrudTest.Domain.Dtos;
using Mc2.CrudTest.Domain.Models.IndependentCreditNotes;
using MediatR;
using ServiceResult;

namespace Mc2.CrudTest.Application.CQRS.IndependentCreditNotes.Create
{
    public class CreateIndependentCreditNoteCommand: IRequest<bool>
    {
        public IndependentCreditNoteInPutDto IndependentCreditNoteInPutDto { get; private set; }

        public CreateIndependentCreditNoteCommand(IndependentCreditNoteInPutDto independentCreditNoteInPutDto)
        {
            IndependentCreditNoteInPutDto = independentCreditNoteInPutDto;
        }
    }
}
