using Mc2.CrudTest.Application.Interfaces;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Mc2.CrudTest.Application.CQRS.IndependentCreditNotes.GetById
{
    public class GetIndependentCreditNoteByIdQueryHandler : IRequestHandler<GetIndependentCreditNoteByIdQuery, GetIndependentCreditNoteByIdQueryResult>
    {
        private readonly IIndependentCreditNoteRepository _independentCreditNoteRepository;

        public GetIndependentCreditNoteByIdQueryHandler(IIndependentCreditNoteRepository independentCreditNoteRepository)
        {
            _independentCreditNoteRepository = independentCreditNoteRepository;
        }

        public async Task<GetIndependentCreditNoteByIdQueryResult> Handle(GetIndependentCreditNoteByIdQuery request, CancellationToken cancellationToken)
        {
            var independentCreditNo = await _independentCreditNoteRepository.GetById(request.Id);

            return new GetIndependentCreditNoteByIdQueryResult(independentCreditNo.CreditNumber, independentCreditNo.ExternalCreditNumber, independentCreditNo.InvoiceStatus, independentCreditNo.TotalAmount);
        }
    }
}
