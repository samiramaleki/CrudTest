using Mc2.CrudTest.Domain.Dtos.Invoices;
using MediatR;
using System.Collections.Generic;

namespace Mc2.CrudTest.Application.CQRS.Invoices.List
{
    public class GetInvoiceListQuery: IRequest<List<DocumentOutPutDto>>
    {
    }
}
