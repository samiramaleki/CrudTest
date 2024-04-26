using Mc2.CrudTest.Domain.Enums;
using System;

namespace Mc2.CrudTest.Domain.Dtos.Invoices
{
    public class DependentCreditNoteInputDto
    {
        public Guid? Id { get; set; }
        public int CreditNumber { get;  set; }
        public string ExternalCreditNumber { get;  set; }
        public Status CreditStatus { get;  set; }
        public decimal TotalAmount { get;  set; }
        public Guid InvoiceId { get; set; }
    }
}
