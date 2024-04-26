using Mc2.CrudTest.Domain.Dtos.Invoices;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mc2.CrudTest.Application.CQRS.Invoices.Simple
{
    public class GetInvoiceSimpleQuery: IRequest<List<GetInvoiceSimple>>
    {
    }
}
