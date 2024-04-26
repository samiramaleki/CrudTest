using MediatR;
using System;

namespace Mc2.CrudTest.Application.CQRS.Invoices.GetById
{
    public class GetInvoiceByIdQuery: IRequest<GetInvoiceByIdQueryResult>
    {
        public Guid Id { get; private set; }

        public GetInvoiceByIdQuery(Guid id)
        {
            Id = id;
        }
    }
}
