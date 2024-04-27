using Mc2.CrudTest.Application.Interfaces;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Mc2.CrudTest.Application.CQRS.DependentCreditNotes.GetById
{
    public class GetDependentCreditNoteByIdQueryHandler : IRequestHandler<GetDependentCreditNoteByIdQuery, GetDependentCreditNoteByIdQueryResult>
    {
        private readonly IDependentCreditNoteRepository _dependentCreditNoteRepository;

        public GetDependentCreditNoteByIdQueryHandler(IDependentCreditNoteRepository dependentCreditNoteRepository)
        {
            _dependentCreditNoteRepository = dependentCreditNoteRepository;
        }

        public async Task<GetDependentCreditNoteByIdQueryResult> Handle(GetDependentCreditNoteByIdQuery request, CancellationToken cancellationToken)
        {
            var dependentCreditNote = await _dependentCreditNoteRepository.GetById(request.Id);
            return new GetDependentCreditNoteByIdQueryResult(dependentCreditNote.CreditNumber, dependentCreditNote.ExternalCreditNumber, dependentCreditNote.CreditStatus, dependentCreditNote.TotalAmount, dependentCreditNote.InvoiceId);
        }
    }
}
