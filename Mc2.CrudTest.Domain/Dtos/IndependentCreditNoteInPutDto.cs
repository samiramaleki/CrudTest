using Mc2.CrudTest.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mc2.CrudTest.Domain.Dtos
{
    public class IndependentCreditNoteInPutDto
    {
        public Guid? IndependentCreditNoteId { get; set; }
        public int CreditNumber { get; private set; }
        public string ExternalCreditNumber { get; private set; }
        public Status CreditStatus { get; private set; }
        public decimal TotalAmount { get; private set; }
    }
}
