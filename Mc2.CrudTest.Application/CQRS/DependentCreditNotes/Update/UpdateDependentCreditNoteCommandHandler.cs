using Mc2.CrudTest.Application.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Mc2.CrudTest.Application.CQRS.DependentCreditNotes.Update
{
    public class UpdateDependentCreditNoteCommandHandler : IRequestHandler<UpdateDependentCreditNoteCommand, bool>
    {
        private readonly IDependentCreditNoteRepository _dependentCreditNoteRepository;
        private readonly IInvoiceRepository _invoiceRepository;
        private readonly IUnitOfWork _unitOfWork;

        public UpdateDependentCreditNoteCommandHandler(IDependentCreditNoteRepository dependentCreditNoteRepository, IInvoiceRepository invoiceRepository, IUnitOfWork unitOfWork)
        {
            _dependentCreditNoteRepository = dependentCreditNoteRepository;
            _invoiceRepository = invoiceRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<bool> Handle(UpdateDependentCreditNoteCommand request, CancellationToken cancellationToken)
        {
            var invoice = await _invoiceRepository.GetById(request.DependentCreditNoteInputDto.InvoiceId) ?? throw new Exception("InvoiceId not found");

            var dependentCreditNote = await _dependentCreditNoteRepository.GetById(request.DependentCreditNoteInputDto.Id.Value) ?? throw new Exception("Id not found");

            dependentCreditNote.Update(request.DependentCreditNoteInputDto.CreditNumber, request.DependentCreditNoteInputDto.ExternalCreditNumber, request.DependentCreditNoteInputDto.CreditStatus, request.DependentCreditNoteInputDto.TotalAmount, invoice);

            _unitOfWork.Commit();
            return true;
        }
    }
}
