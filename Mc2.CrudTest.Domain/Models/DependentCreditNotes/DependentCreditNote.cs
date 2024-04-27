using Mc2.CrudTest.Domain.Enums;
using Mc2.CrudTest.Domain.Models.Invoices;
using System;

namespace Mc2.CrudTest.Domain.Models.DependentCreditNotes
{
    public class DependentCreditNote
    {
        public DependentCreditNote()
        {

        }

        public Guid Id { get; set; }
        public long CreditNumber { get; private set; }
        public string ExternalCreditNumber { get; private set; }
        public Status CreditStatus { get; private set; }
        public decimal TotalAmount { get; private set; }
        public Guid InvoiceId { get; private set; }
        public Invoice Invoice { get; private set; }

        private DependentCreditNote(long creditNumber, string externalCreditNumber, Status creditStatus, decimal totalAmount, Invoice invoice)
        {
            Validation(creditNumber, externalCreditNumber, totalAmount);

            Id = Guid.NewGuid();
            CreditNumber = creditNumber;
            ExternalCreditNumber = externalCreditNumber;
            CreditStatus = creditStatus;
            TotalAmount = totalAmount;
            Invoice = invoice;
        }

        public static DependentCreditNote Create(long creditNumber, string externalCreditNumber, Status creditStatus, decimal totalAmount, Invoice invoice)
            => new (creditNumber, externalCreditNumber, creditStatus, totalAmount, invoice);

        public void Update(long creditNumber, string externalCreditNumber, Status creditStatus, decimal totalAmount, Invoice invoice)
        {
            Validation(creditNumber, externalCreditNumber, totalAmount);

            CreditNumber = creditNumber;
            ExternalCreditNumber = externalCreditNumber;
            CreditStatus = creditStatus;
            TotalAmount = totalAmount;
            Invoice= invoice;
        }

        private void Validation(long creditNumber, string externalCreditNumber, decimal totalAmount)
        {
            if (creditNumber == 0)
                throw new Exception("CreditNumber can’t be empty.");

            if (string.IsNullOrWhiteSpace(externalCreditNumber))
                throw new Exception("ExternalCreditNumber can’t be empty.");

            if (totalAmount == 0)
                throw new Exception("TotalAmount can’t be empty.");
            if (totalAmount < 0)
                throw new Exception("TotalAmount should be greater than zero.");
        }
    }
}
