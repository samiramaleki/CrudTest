using FluentValidation;

namespace Mc2.CrudTest.Application.CQRS.Invoices.Create
{
    public class CreateInvoiceCommandValidator: AbstractValidator<CreateInvoiceCommand>
    {
        public CreateInvoiceCommandValidator()
        {
            RuleFor(c => c.InvoiceInputDto.InvoiceNumber).NotEmpty().WithMessage("InvoiceNumber can’t be empty");
            RuleFor(c => c.InvoiceInputDto.InvoiceNumber.ToString()).Length(10).WithMessage("InvoiceNumber can’t be empty");

            RuleFor(c => c.InvoiceInputDto.ExternalInvoiceNumber).NotNull().NotEmpty().WithMessage("ExternalInvoiceNumber can’t be empty");
            RuleFor(c => c.InvoiceInputDto.ExternalInvoiceNumber).Length(10).WithMessage("ExternalInvoiceNumber includes 10 characters");

            RuleFor(c => c.InvoiceInputDto.TotalAmount).NotEmpty().WithMessage("TotalAmount sIt can’t be empty");
            RuleFor(c => c.InvoiceInputDto.TotalAmount).GreaterThan(0).WithMessage("TotalAmount should be less than zero.");
        }
    }
}
