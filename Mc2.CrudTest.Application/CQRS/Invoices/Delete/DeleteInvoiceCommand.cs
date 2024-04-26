using MediatR;
using System;

namespace Mc2.CrudTest.Application.CQRS.Invoices.Delete
{
    public class DeleteInvoiceCommand: IRequest<bool>
    {
        public Guid Id { get; set; }
    }
}
