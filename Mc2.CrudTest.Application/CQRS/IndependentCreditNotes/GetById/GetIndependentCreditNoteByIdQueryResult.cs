using Mc2.CrudTest.Domain.Enums;

namespace Mc2.CrudTest.Application.CQRS.IndependentCreditNotes.GetById
{
    public class GetIndependentCreditNoteByIdQueryResult
    {
        public long CreditNumber { get; private set; }
        public string ExternalCreditNumber { get; private set; }
        public Status CreditStatus { get; private set; }
        public decimal TotalAmount { get; private set; }

        public GetIndependentCreditNoteByIdQueryResult(long creditNumber, string externalCreditNumber, Status creditStatus, decimal totalAmount)
        {
            CreditNumber = creditNumber;
            ExternalCreditNumber = externalCreditNumber;
            CreditStatus = creditStatus;
            TotalAmount = totalAmount;
        }
    }
}
