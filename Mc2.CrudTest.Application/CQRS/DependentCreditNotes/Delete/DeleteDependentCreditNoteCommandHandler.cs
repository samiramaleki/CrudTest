using Mc2.CrudTest.Application.Interfaces;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Mc2.CrudTest.Application.CQRS.DependentCreditNotes.Delete
{
    public class DeleteDependentCreditNoteCommandHandler : IRequestHandler<DeleteDependentCreditNoteCommand, bool>
    {
        private readonly IDependentCreditNoteRepository _dependentCreditNoteRepository;
        private readonly IUnitOfWork _unitOfWork;

        public DeleteDependentCreditNoteCommandHandler(IUnitOfWork unitOfWork, IDependentCreditNoteRepository dependentCreditNoteRepository)
        {
            _unitOfWork = unitOfWork;
            _dependentCreditNoteRepository = dependentCreditNoteRepository;
        }

        public async Task<bool> Handle(DeleteDependentCreditNoteCommand request, CancellationToken cancellationToken)
        {
            var dependentCreditNote = await _dependentCreditNoteRepository.GetById(request.Id) ?? throw new Exception("Id not found");

            await _dependentCreditNoteRepository.Delete(dependentCreditNote);
            _unitOfWork.Commit();

            return true;
        }
    }
}
