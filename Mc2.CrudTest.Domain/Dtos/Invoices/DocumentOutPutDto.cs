using Mc2.CrudTest.Domain.Enums;
using System;

namespace Mc2.CrudTest.Domain.Dtos.Invoices
{
    public class DocumentOutPutDto
    {
        public Guid? InvoiceId { get; set; }
        public Guid? DependentCreditNoteId { get; set; }
        public Guid IndependentCreditNoteId { get; set; }
        public int InvoiceNumber { get; set; }
        public string ExternalInvoiceNumber { get; set; }
        public decimal InvoiceTotalAmount { get; set; }
        public string InvoiceStatus { get; set; }
        public int CreditNumber { get; set; }
        public string ExternalCreditNumber { get; set; }
        public string CreditStatus { get; set; }
        public decimal CreditTotalAmount { get; set; }
    }
}
