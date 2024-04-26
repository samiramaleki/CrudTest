using FluentValidation;

namespace Mc2.CrudTest.Application.CQRS.IndependentCreditNotes.Update
{
    public class UpdateIndependentCreditNoteCommandValidator: AbstractValidator<UpdateIndependentCreditNoteCommand>
    {
        public UpdateIndependentCreditNoteCommandValidator()
        {
            RuleFor(c => c.IndependentCreditNoteInPutDto.CreditNumber).NotEmpty().WithMessage("CreditNumber can’t be empty");
            RuleFor(c => c.IndependentCreditNoteInPutDto.CreditNumber.ToString()).Length(10).WithMessage("CreditNumber includes 10 digits.");

            RuleFor(c => c.IndependentCreditNoteInPutDto.ExternalCreditNumber).NotEmpty().WithMessage("ExternalCreditNumber can’t be empty");
            RuleFor(c => c.IndependentCreditNoteInPutDto.ExternalCreditNumber.ToString()).Length(10).WithMessage("ExternalCreditNumber includes 10 characters.");

            RuleFor(c => c.IndependentCreditNoteInPutDto.TotalAmount).NotEmpty().WithMessage("TotalAmount It can’t be empty.");
            RuleFor(c => c.IndependentCreditNoteInPutDto.TotalAmount).GreaterThan(0).WithMessage("TotalAmount should be less than zero.");
        }
    }
}
