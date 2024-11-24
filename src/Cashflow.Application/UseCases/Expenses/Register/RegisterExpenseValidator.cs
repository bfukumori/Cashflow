using Cashflow.Communication.Requests.Expenses;
using Cashflow.Exception;
using FluentValidation;

namespace Cashflow.Application.UseCases.Expenses.Register;
public class RegisterExpenseValidator : AbstractValidator<RequestRegisterExpenseJson>
{
    public RegisterExpenseValidator()
    {
        RuleFor(request => request.Title)
            .NotEmpty().WithMessage(ResourceErrorMessages.TITLE_REQUIRED);

        RuleFor(request => request.Date)
            .LessThanOrEqualTo(DateTime.UtcNow).WithMessage(ResourceErrorMessages.DATE_CAN_NOT_BE_IN_THE_FUTURE);

        RuleFor(request => request.Amount)
            .GreaterThan(0).WithMessage(ResourceErrorMessages.AMOUNT_MUST_BE_GREATER_THAN_ZERO);

        RuleFor(request => request.PaymentType)
            .IsInEnum().WithMessage(ResourceErrorMessages.INVALID_PAYMENT_TYPE);
    }
}
