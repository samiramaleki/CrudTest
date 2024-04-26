using Mc2.CrudTest.Domain.Models.Invoices;
using Mc2.CrudTest.Domain.UnitTest.Domain.Fixtures;

namespace Mc2.CrudTest.Domain.UnitTest.Domain.Invoices
{
    public class InvoiceTests : IClassFixture<InvoiceFixture>
    {
        private readonly InvoiceFixture _invoiceFixture;

        public InvoiceTests(InvoiceFixture invoiceFixture)
        {
            _invoiceFixture = invoiceFixture;
        }

        [Fact]
        public void Create_Invoice_When_InvoiceNumber_Is_Empty_Throw_Exception()
        {
            var expectation = "InvoiceNumber can’t be empty.";

            var result = Assert.Throws<Exception>(() =>
                Invoice.Create(0, _invoiceFixture.ExternalInvoiceNumber, _invoiceFixture.InvoiceStatus, _invoiceFixture.TotalAmount));

            Assert.Equal(result.Message, expectation);
        }

        [Fact]
        public void Create_Invoice_When_ExternalInvoiceNumber_Is_Empty_Throw_Exception()
        {
            var expectation = "ExternalInvoiceNumber can’t be empty.";

            var result = Assert.Throws<Exception>(() =>
                Invoice.Create(_invoiceFixture.InvoiceNumber, "", _invoiceFixture.InvoiceStatus, _invoiceFixture.TotalAmount));

            Assert.Equal(result.Message, expectation);
        }

        [Fact]
        public void Create_Invoice_When_TotalAmount_Is_Empty_Throw_Exception()
        {
            var expectation = "TotalAmount can’t be empty.";

            var result = Assert.Throws<Exception>(() =>
                Invoice.Create(_invoiceFixture.InvoiceNumber, _invoiceFixture.ExternalInvoiceNumber, _invoiceFixture.InvoiceStatus, 0));

            Assert.Equal(result.Message, expectation);
        }

        [Fact]
        public void Create_Invoice_When_TotalAmount_Is_Less_Than_Zero_Throw_Exception()
        {
            var expectation = "TotalAmount should be greater than zero.";

            var result = Assert.Throws<Exception>(() =>
                Invoice.Create(_invoiceFixture.InvoiceNumber, _invoiceFixture.ExternalInvoiceNumber, _invoiceFixture.InvoiceStatus, -100));

            Assert.Equal(result.Message, expectation);
        }
    }
}
