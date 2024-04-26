using Mc2.CrudTest.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mc2.CrudTest.Domain.Models
{
    public abstract class Document
    {
        public int CreditNumber { get; private set; }
        public string ExternalCreditNumber { get; private set; }
        public Status Status { get; private set; }
        public decimal TotalAmount { get; private set; }

        protected Document(string externalInvoiceNumber, Status invoiceStatus, decimal totalAmount)
        {

        }
    }
}
