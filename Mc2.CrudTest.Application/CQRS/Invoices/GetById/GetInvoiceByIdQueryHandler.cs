using Mc2.CrudTest.Application.Interfaces;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Mc2.CrudTest.Application.CQRS.Invoices.GetById
{
    public class GetInvoiceByIdQueryHandler : IRequestHandler<GetInvoiceByIdQuery, GetInvoiceByIdQueryResult>
    {
        private readonly IInvoiceRepository _invoiceRepository;

        public GetInvoiceByIdQueryHandler(IInvoiceRepository invoiceRepository)
        {
            _invoiceRepository = invoiceRepository;
        }

        public async Task<GetInvoiceByIdQueryResult> Handle(GetInvoiceByIdQuery query, CancellationToken cancellationToken)
        {
            var result = await _invoiceRepository.GetById(query.Id);

            return new GetInvoiceByIdQueryResult(result.InvoiceNumber, result.ExternalInvoiceNumber, result.InvoiceStatus, result.TotalAmount);
        }
    }
}
