using Mc2.CrudTest.Domain.Enums;

namespace Mc2.CrudTest.Domain.UnitTest.Domain.Fixtures
{
    public class InvoiceFixture : IDisposable
    {
        public long InvoiceNumber { get;  set; }
        public string ExternalInvoiceNumber { get;  set; }= string.Empty;
        public Status InvoiceStatus { get;  set; }
        public decimal TotalAmount { get;  set; }

        public InvoiceFixture()
        {
            FillMock();
        }

        public void FillMock()
        {
            InvoiceNumber = 1234567890;
            ExternalInvoiceNumber = "ABC123XYZ";
            InvoiceStatus = Status.WaitingForApproval;
            TotalAmount = 1000.00m;
        }

        public void Dispose()
        {
           ExternalInvoiceNumber = string.Empty;
        }
    }
}
