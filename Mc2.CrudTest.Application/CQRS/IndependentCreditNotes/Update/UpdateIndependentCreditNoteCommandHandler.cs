using Mc2.CrudTest.Application.Interfaces;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Mc2.CrudTest.Application.CQRS.IndependentCreditNotes.Update
{
    public class UpdateIndependentCreditNoteCommandHandler : IRequestHandler<UpdateIndependentCreditNoteCommand, bool>
    {
        private readonly IIndependentCreditNoteRepository  _independentCreditNoteRepository;
        private readonly IUnitOfWork _unitOfWork;

        public UpdateIndependentCreditNoteCommandHandler(IIndependentCreditNoteRepository independentCreditNoteRepository, IUnitOfWork unitOfWork)
        {
            _independentCreditNoteRepository = independentCreditNoteRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<bool> Handle(UpdateIndependentCreditNoteCommand request, CancellationToken cancellationToken)
        {
            var independentCreditNo = await _independentCreditNoteRepository.GetById(request.IndependentCreditNoteInPutDto.IndependentCreditNoteId.Value) ?? throw new Exception("Id not found");

            independentCreditNo.Update(request.IndependentCreditNoteInPutDto.CreditNumber,
                                 request.IndependentCreditNoteInPutDto.ExternalCreditNumber,
                                 request.IndependentCreditNoteInPutDto.CreditStatus,
                                 request.IndependentCreditNoteInPutDto.TotalAmount);

            _unitOfWork.Commit();
            return true;
        }
    }
}
