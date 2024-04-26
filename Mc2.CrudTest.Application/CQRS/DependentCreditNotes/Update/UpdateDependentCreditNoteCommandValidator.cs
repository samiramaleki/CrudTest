using FluentValidation;

namespace Mc2.CrudTest.Application.CQRS.DependentCreditNotes.Update
{
    public class UpdateDependentCreditNoteCommandValidator: AbstractValidator<UpdateDependentCreditNoteCommand>
    {
        public UpdateDependentCreditNoteCommandValidator()
        {
            RuleFor(c => c.DependentCreditNoteInputDto.CreditNumber).NotEmpty().WithMessage("InvoiceNumber can’t be empty");
            RuleFor(c => c.DependentCreditNoteInputDto.CreditNumber.ToString()).Length(10).WithMessage("InvoiceNumber includes 10 digits");

            RuleFor(c => c.DependentCreditNoteInputDto.ExternalCreditNumber).NotNull().NotEmpty().WithMessage("ExternalInvoiceNumber can’t be empty");
            RuleFor(c => c.DependentCreditNoteInputDto.ExternalCreditNumber).Length(10).WithMessage("ExternalInvoiceNumber includes 10 characters");

            RuleFor(c => c.DependentCreditNoteInputDto.TotalAmount).NotEmpty().WithMessage("TotalAmount sIt can’t be empty");
            RuleFor(c => c.DependentCreditNoteInputDto.TotalAmount).GreaterThan(0).WithMessage("TotalAmount should be less than zero.");
        }
    }
}

