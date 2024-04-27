using Mc2.CrudTest.Domain.Enums;
using System;

namespace Mc2.CrudTest.Domain.Models.IndependentCreditNotes
{
    public class IndependentCreditNote
    {
        public IndependentCreditNote()
        {

        }

        public Guid Id { get; set; }
        public long CreditNumber { get; private set; }
        public string ExternalCreditNumber { get; private set; }
        public Status InvoiceStatus { get; private set; }
        public decimal TotalAmount { get; private set; }

        private IndependentCreditNote(long creditNumber, string externalCreditNumber, Status invoiceStatus, decimal totalAmount)
        {
            Validation(creditNumber, externalCreditNumber, totalAmount);

            Id = Guid.NewGuid();
            CreditNumber = creditNumber;
            ExternalCreditNumber = externalCreditNumber;
            InvoiceStatus = invoiceStatus;
            TotalAmount = totalAmount;
        }

        public static IndependentCreditNote Create(long creditNumber, string externalCreditNumber, Status invoiceStatus, decimal totalAmount)
         => new(creditNumber, externalCreditNumber, invoiceStatus, totalAmount);

        public void Update(long creditNumber, string externalCreditNumber, Status invoiceStatus, decimal totalAmount)
        {
            Validation(creditNumber, externalCreditNumber, totalAmount);

            CreditNumber = creditNumber;
            ExternalCreditNumber = externalCreditNumber;
            InvoiceStatus = invoiceStatus;
            TotalAmount = totalAmount;
            InvoiceStatus = invoiceStatus;
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
