using Mc2.CrudTest.Domain.Dtos.Invoices;
using Mc2.CrudTest.Domain.Models.Invoices;
using MediatR;
using ServiceResult;

namespace Mc2.CrudTest.Application.CQRS.Invoices.Create
{
    public class CreateInvoiceCommand: IRequest<bool>
    {
        public InvoiceInputDto InvoiceInputDto { get; private set; }

        public CreateInvoiceCommand(InvoiceInputDto invoiceInputDto)
        {
            InvoiceInputDto = invoiceInputDto;
        }
    }
}
