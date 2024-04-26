using Mc2.CrudTest.Application.Interfaces;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Mc2.CrudTest.Application.CQRS.IndependentCreditNotes.Delete
{
    public class DeleteIndependentCreditNoteCommandHandler : IRequestHandler<DeleteIndependentCreditNoteCommand, bool>
    {
        private readonly IIndependentCreditNoteRepository _independentCreditNoteRepository;
        private readonly IUnitOfWork _unitOfWork;

        public DeleteIndependentCreditNoteCommandHandler(IIndependentCreditNoteRepository independentCreditNoteRepository, IUnitOfWork unitOfWork)
        {
            _independentCreditNoteRepository = independentCreditNoteRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<bool> Handle(DeleteIndependentCreditNoteCommand request, CancellationToken cancellationToken)
        {
            var independentCreditNo = await _independentCreditNoteRepository.GetById(request.Id) ?? throw new Exception("Id not found");

            await _independentCreditNoteRepository.Delete(independentCreditNo);
            _unitOfWork.Commit();
            return true;
        }
    }
}
