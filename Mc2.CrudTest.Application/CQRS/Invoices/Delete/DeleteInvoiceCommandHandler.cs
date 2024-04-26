using Mc2.CrudTest.Application.Interfaces;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Mc2.CrudTest.Application.CQRS.Invoices.Delete
{
    public class DeleteInvoiceCommandHandler : IRequestHandler<DeleteInvoiceCommand, bool>
    {
        private readonly IInvoiceRepository _invoiceRepository;
        private readonly IUnitOfWork _unitOfWork;

        public DeleteInvoiceCommandHandler(IInvoiceRepository invoiceRepository, IUnitOfWork unitOfWork)
        {
            _invoiceRepository = invoiceRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<bool> Handle(DeleteInvoiceCommand request, CancellationToken cancellationToken)
        {
            var invoice = await _invoiceRepository.GetById(request.Id) ?? throw new Exception("InvoiceId not found");

           await _invoiceRepository.Delete(invoice);
            _unitOfWork.Commit();
            return true;
        }
    }
}
