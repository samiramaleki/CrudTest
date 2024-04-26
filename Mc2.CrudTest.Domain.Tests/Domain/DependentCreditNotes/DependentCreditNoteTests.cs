using Mc2.CrudTest.Domain.Models.DependentCreditNotes;
using Mc2.CrudTest.Domain.UnitTest.Domain.Fixtures;

namespace Mc2.CrudTest.Domain.UnitTest.Domain.DependentCreditNotes
{
    public class DependentCreditNoteTests: IClassFixture<DependentCreditNoteFixture>
    {
        private readonly DependentCreditNoteFixture _dependentCreditNoteFixture;

        public DependentCreditNoteTests(DependentCreditNoteFixture dependentCreditNoteFixture)
        {
            _dependentCreditNoteFixture = dependentCreditNoteFixture;
        }

        [Fact]
        public void Create_DependentCreditNote_When_CreditNumber_Is_Empty_Throw_Exception()
        {
            var expectation = "CreditNumber can’t be empty.";

            var result = Assert.Throws<Exception>(() =>
                DependentCreditNote.Create(0, _dependentCreditNoteFixture.ExternalCreditNumber, _dependentCreditNoteFixture.CreditStatus, _dependentCreditNoteFixture.TotalAmount, _dependentCreditNoteFixture.Invoice));

            Assert.Equal(result.Message, expectation);
        }

        [Fact]
        public void Create_DependentCreditNote_When_ExternalCreditNumber_Is_Empty_Throw_Exception()
        {
            var expectation = "ExternalCreditNumber can’t be empty.";

            var result = Assert.Throws<Exception>(() =>
                 DependentCreditNote.Create(_dependentCreditNoteFixture.CreditNumber, "", _dependentCreditNoteFixture.CreditStatus, _dependentCreditNoteFixture.TotalAmount, _dependentCreditNoteFixture.Invoice));

            Assert.Equal(result.Message, expectation);
        }

        [Fact]
        public void Create_DependentCreditNote_When_TotalAmount_Is_Empty_Throw_Exception()
        {
            var expectation = "TotalAmount can’t be empty.";

            var result = Assert.Throws<Exception>(() =>
                DependentCreditNote.Create(_dependentCreditNoteFixture.CreditNumber, _dependentCreditNoteFixture.ExternalCreditNumber, _dependentCreditNoteFixture.CreditStatus, 0, _dependentCreditNoteFixture.Invoice));

            Assert.Equal(result.Message, expectation);
        }

        [Fact]
        public void Create_DependentCreditNote_When_TotalAmount_Is_Less_Than_Zero_Throw_Exception()
        {
            var expectation = "TotalAmount should be greater than zero.";

            var result = Assert.Throws<Exception>(() =>
                 DependentCreditNote.Create(_dependentCreditNoteFixture.CreditNumber, _dependentCreditNoteFixture.ExternalCreditNumber, _dependentCreditNoteFixture.CreditStatus, -100, _dependentCreditNoteFixture.Invoice));

            Assert.Equal(result.Message, expectation);
        }
    }
}
