using Mc2.CrudTest.Application.Interfaces;
using Mc2.CrudTest.Domain.Models.Invoices;
using MediatR;
using ServiceResult;
using System.Threading;
using System.Threading.Tasks;

namespace Mc2.CrudTest.Application.CQRS.Invoices.Create
{
    public class CreateInvoiceCommandHandler : IRequestHandler<CreateInvoiceCommand, bool>
    {
        private readonly IInvoiceRepository _invoiceRepository;
        private readonly IUnitOfWork _unitOfWork;

        public CreateInvoiceCommandHandler(IInvoiceRepository invoiceRepository, IUnitOfWork unitOfWork)
        {
            _invoiceRepository = invoiceRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<bool> Handle(CreateInvoiceCommand request, CancellationToken cancellationToken)
        {
            var invoice = Invoice.Create(request.InvoiceInputDto.InvoiceNumber, request.InvoiceInputDto.ExternalInvoiceNumber, request.InvoiceInputDto.InvoiceStatus, request.InvoiceInputDto.TotalAmount);

            await _invoiceRepository.Create(invoice);

            _unitOfWork.Commit();
            return true;
        }
    }
}
