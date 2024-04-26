using Mc2.CrudTest.Application.Interfaces;
using Mc2.CrudTest.Domain.Models.DependentCreditNotes;
using Mc2.CrudTest.Domain.Models.Invoices;
using MediatR;
using ServiceResult;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Mc2.CrudTest.Application.CQRS.DependentCreditNotes.Create
{
    public class CreateDependentCreditNoteCommandHandler : IRequestHandler<CreateDependentCreditNoteCommand, bool>
    {
        private readonly IDependentCreditNoteRepository _dependentCreditNoteRepository;
        private readonly IInvoiceRepository _invoiceRepository;
        private readonly IUnitOfWork _unitOfWork;

        public CreateDependentCreditNoteCommandHandler(IDependentCreditNoteRepository dependentCreditNoteRepository, IInvoiceRepository invoiceRepository, IUnitOfWork unitOfWork)
        {
            _dependentCreditNoteRepository = dependentCreditNoteRepository;
            _invoiceRepository = invoiceRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<bool> Handle(CreateDependentCreditNoteCommand request, CancellationToken cancellationToken)
        {
            var invoice = await _invoiceRepository.GetById(request.DependentCreditNoteInputDto.InvoiceId) ?? throw new Exception("InvoiceId not found");

            var dependentCreditNote = DependentCreditNote.Create(request.DependentCreditNoteInputDto.CreditNumber, request.DependentCreditNoteInputDto.ExternalCreditNumber, request.DependentCreditNoteInputDto.CreditStatus, request.DependentCreditNoteInputDto.TotalAmount, invoice);

           await _dependentCreditNoteRepository.Create(dependentCreditNote);
            _unitOfWork.Commit();
            return true;
        }
    }
}
