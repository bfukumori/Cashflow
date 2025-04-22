using Cashflow.Communication.Requests.Expenses;

namespace Cashflow.Application.UseCases.Expenses.Update;
public interface IUpdateExpenseUseCase
{
    Task Execute(long id, RequestExpenseJson request);
}
