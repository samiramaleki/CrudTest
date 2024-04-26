using Mc2.CrudTest.Domain.Dtos;
using MediatR;

namespace Mc2.CrudTest.Application.CQRS.IndependentCreditNotes.Update
{
    public class UpdateIndependentCreditNoteCommand: IRequest<bool>
    {
        public IndependentCreditNoteInPutDto IndependentCreditNoteInPutDto { get; private set; }

        public UpdateIndependentCreditNoteCommand(IndependentCreditNoteInPutDto independentCreditNoteInPutDto = null)
        {
            IndependentCreditNoteInPutDto = independentCreditNoteInPutDto;
        }
    }
}
