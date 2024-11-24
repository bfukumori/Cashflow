using Cashflow.Communication.Requests.Expenses;
using Cashflow.Communication.Responses.Expenses;

namespace Cashflow.Application.UseCases.Expenses.Register;
public interface IRegisterExpenseUseCase
{
    Task<ResponseRegisteredExpenseJson> Execute(RequestRegisterExpenseJson request);
}
