using Mc2.CrudTest.Application.Interfaces;
using Mc2.CrudTest.Domain.Dtos.Invoices;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Mc2.CrudTest.Application.CQRS.Invoices.Simple
{
    public class GetInvoiceSimpleQueryHandler : IRequestHandler<GetInvoiceSimpleQuery, List<GetInvoiceSimple>>
    {
        private readonly IInvoiceRepository _invoiceRepository;

        public GetInvoiceSimpleQueryHandler(IInvoiceRepository invoiceRepository)
        {
            _invoiceRepository = invoiceRepository;
        }

        public async Task<List<GetInvoiceSimple>> Handle(GetInvoiceSimpleQuery request, CancellationToken cancellationToken)
        {
           return await _invoiceRepository.GetInvoiceSimpleList(cancellationToken);
        }
    }
}
