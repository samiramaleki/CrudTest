using Mc2.CrudTest.Domain.Dtos.Invoices;
using Mc2.CrudTest.Domain.Models.Invoices;
using MediatR;
using ServiceResult;

namespace Mc2.CrudTest.Application.CQRS.Invoices.Update
{
    public class UpdateInvoiceCommand: IRequest<bool>
    {
        public InvoiceInputDto InvoiceInputDto { get; private set; }

        public UpdateInvoiceCommand(InvoiceInputDto invoiceInputDto)
        {
            InvoiceInputDto = invoiceInputDto;
        }
    }
}
