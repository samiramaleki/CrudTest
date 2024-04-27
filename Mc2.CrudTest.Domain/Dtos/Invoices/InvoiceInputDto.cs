using Mc2.CrudTest.Domain.Enums;
using System;

namespace Mc2.CrudTest.Domain.Dtos.Invoices
{
    public class InvoiceInputDto
    {
        public Guid? InvoiceId { get; set; }
        public long InvoiceNumber { get; set; }
        public string ExternalInvoiceNumber { get; set; }
        public Status InvoiceStatus { get; set; }
        public decimal TotalAmount { get; set; }
    }
}
