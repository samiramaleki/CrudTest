using Mc2.CrudTest.Domain.Enums;
using Mc2.CrudTest.Domain.Models.DependentCreditNotes;
using ServiceResult;
using System;
using System.Collections.Generic;

namespace Mc2.CrudTest.Domain.Models.Invoices
{
    public class Invoice
    {
        public Invoice()
        {

        }

        public Guid Id { get; set; }
        public long InvoiceNumber { get; private set; }
        public string ExternalInvoiceNumber { get; private set; }
        public Status InvoiceStatus { get; private set; }
        public decimal TotalAmount { get; private set; }
        public IList<DependentCreditNote> DependentCreditNotes { get; set; }

        private Invoice(long invoiceNumber, string externalInvoiceNumber, Status invoiceStatus, decimal totalAmount)
        {
            Validation(invoiceNumber, externalInvoiceNumber, totalAmount);

            Id = Guid.NewGuid();
            InvoiceNumber = invoiceNumber;
            ExternalInvoiceNumber = externalInvoiceNumber;
            InvoiceStatus = invoiceStatus;
            TotalAmount = totalAmount;
        }

        private void Validation(long invoiceNumber, string externalInvoiceNumber, decimal totalAmount)
        {
            if (invoiceNumber == 0)
                throw new Exception("InvoiceNumber can’t be empty.");

            if (string.IsNullOrWhiteSpace(externalInvoiceNumber))
                throw new Exception("ExternalInvoiceNumber can’t be empty.");

            if (totalAmount == 0)
                throw new Exception("TotalAmount can’t be empty.");
            if (totalAmount < 0)
                throw new Exception("TotalAmount should be greater than zero.");
        }

        public static Invoice Create(long invoiceNumber, string externalInvoiceNumber, Status invoiceStatus, decimal totalAmount)
         => new(invoiceNumber, externalInvoiceNumber, invoiceStatus, totalAmount);

        public void Update(long invoiceNumber, string externalInvoiceNumber, Status invoiceStatus, decimal totalAmount)
        {
            Validation(invoiceNumber, externalInvoiceNumber, totalAmount);

            InvoiceNumber = invoiceNumber;
            ExternalInvoiceNumber = externalInvoiceNumber;
            InvoiceStatus = invoiceStatus;
            TotalAmount = totalAmount;
        }
    }
}
