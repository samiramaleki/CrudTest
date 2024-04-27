using Mc2.CrudTest.Domain.Enums;
using System;

namespace Mc2.CrudTest.Application.CQRS.DependentCreditNotes.GetById
{
    public class GetDependentCreditNoteByIdQueryResult
    {
        public GetDependentCreditNoteByIdQueryResult(long creditNumber, string externalCreditNumber, Status creditStatus, decimal totalAmount, Guid invoiceId)
        {
            CreditNumber = creditNumber;
            ExternalCreditNumber = externalCreditNumber;
            CreditStatus = creditStatus;
            TotalAmount = totalAmount;
            InvoiceId = invoiceId;
        }

        public long CreditNumber { get; private set; }
        public string ExternalCreditNumber { get; private set; }
        public Status CreditStatus { get; private set; }
        public decimal TotalAmount { get; private set; }
        public Guid InvoiceId { get; set; }
    }
}
