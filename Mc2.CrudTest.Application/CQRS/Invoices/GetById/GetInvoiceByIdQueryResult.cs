using Mc2.CrudTest.Domain.Enums;

namespace Mc2.CrudTest.Application.CQRS.Invoices.GetById
{
    public class GetInvoiceByIdQueryResult
    {
        public GetInvoiceByIdQueryResult(int invoiceNumber, string externalInvoiceNumber, Status invoiceStatus, decimal totalAmount)
        {
            InvoiceNumber = invoiceNumber;
            ExternalInvoiceNumber = externalInvoiceNumber;
            InvoiceStatus = invoiceStatus;
            TotalAmount = totalAmount;
        }

        public int InvoiceNumber { get; private set; }
        public string ExternalInvoiceNumber { get; private set; }
        public Status InvoiceStatus { get; private set; }
        public decimal TotalAmount { get; private set; }
    }
}
