using Mc2.CrudTest.Application.Interfaces;
using Mc2.CrudTest.Domain.Models.IndependentCreditNotes;
using MediatR;
using ServiceResult;
using System.Threading;
using System.Threading.Tasks;

namespace Mc2.CrudTest.Application.CQRS.IndependentCreditNotes.Create
{
    public class CreateIndependentCreditNoteCommandHandler : IRequestHandler<CreateIndependentCreditNoteCommand, bool>
    {
        private readonly  IIndependentCreditNoteRepository _invoiceRepository;
        private readonly IUnitOfWork _unitOfWork;

        public CreateIndependentCreditNoteCommandHandler(IIndependentCreditNoteRepository independentCreditNoteRepository  , IUnitOfWork unitOfWork)
        {
            _invoiceRepository = independentCreditNoteRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<bool> Handle(CreateIndependentCreditNoteCommand request, CancellationToken cancellationToken)
        {
            var independentCreditNote = IndependentCreditNote.Create(request.IndependentCreditNoteInPutDto.CreditNumber, request.IndependentCreditNoteInPutDto.ExternalCreditNumber, request.IndependentCreditNoteInPutDto.CreditStatus, request.IndependentCreditNoteInPutDto.TotalAmount);

            await _invoiceRepository.Create(independentCreditNote);

            _unitOfWork.Commit();
            return true;
        }

    }
}
