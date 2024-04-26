using Mc2.CrudTest.Application.Interfaces;
using Mc2.CrudTest.Domain.Models.Invoices;
using MediatR;
using ServiceResult;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Mc2.CrudTest.Application.CQRS.Invoices.Update
{
    public class UpdateInvoiceCommandHandler : IRequestHandler<UpdateInvoiceCommand, bool>
    {
        private readonly IInvoiceRepository _invoiceRepository;
        private readonly IUnitOfWork _unitOfWork;

        public UpdateInvoiceCommandHandler(IInvoiceRepository invoiceRepository, IUnitOfWork unitOfWork)
        {
            _invoiceRepository = invoiceRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<bool> Handle(UpdateInvoiceCommand request, CancellationToken cancellationToken)
        {
            var invoice = await _invoiceRepository.GetById(request.InvoiceInputDto.InvoiceId.Value) ?? throw new Exception("InvoiceId not found");

            invoice.Update(request.InvoiceInputDto.InvoiceNumber, request.InvoiceInputDto.ExternalInvoiceNumber, request.InvoiceInputDto.InvoiceStatus, request.InvoiceInputDto.TotalAmount);

            await _invoiceRepository.Update(invoice);
            _unitOfWork.Commit();
            return true;
        }
    }
}
