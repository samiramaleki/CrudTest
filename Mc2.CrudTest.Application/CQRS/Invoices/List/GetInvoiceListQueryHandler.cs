using Mc2.CrudTest.Application.Interfaces;
using Mc2.CrudTest.Domain.Dtos.Invoices;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Mc2.CrudTest.Application.CQRS.Invoices.List
{
    public class GetInvoiceListQueryHandler : IRequestHandler<GetInvoiceListQuery, List<DocumentOutPutDto>>
    {
        private readonly IInvoiceRepository _invoiceRepository;

        public GetInvoiceListQueryHandler(IInvoiceRepository invoiceRepository)
        {
            _invoiceRepository = invoiceRepository;
        }

        public async Task<List<DocumentOutPutDto>> Handle(GetInvoiceListQuery request, CancellationToken cancellationToken)
        {
            return await _invoiceRepository.GetList(cancellationToken);
        }
    }
}
