using Mc2.CrudTest.Domain.Enums;
using Mc2.CrudTest.Domain.Models.Invoices;

namespace Mc2.CrudTest.Domain.UnitTest.Domain.Fixtures
{
    public class DependentCreditNoteFixture: IDisposable
    {
        public long CreditNumber { get;  set; }
        public string ExternalCreditNumber { get;  set; }= string.Empty;
        public Status CreditStatus { get;  set; }
        public decimal TotalAmount { get;  set; }
        public Invoice Invoice { get; set; }

        public DependentCreditNoteFixture()
        {
            FillMock();
        }

        public void FillMock()
        {
            var invoice = Invoice.Create(1234567890, "ABC123XYZ", Status.Approved, 1000.00m);

            CreditNumber = 1234567890;
            ExternalCreditNumber = "ABC123XYZ";
            CreditStatus = Status.WaitingForApproval;
            TotalAmount = 1000.00m;
            Invoice = invoice;
        }

        public void Dispose()
        {
            ExternalCreditNumber = string.Empty;
        }
    }
}
