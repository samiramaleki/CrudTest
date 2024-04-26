using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mc2.CrudTest.Domain.Dtos.Invoices
{
    public class GetInvoiceSimple
    {
        public Guid Id { get; set; }
        public int InvoiceNumber { get; set; }
    }
}
