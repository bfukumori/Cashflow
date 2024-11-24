
using Cashflow.Communication.Responses.Expenses;

namespace Cashflow.Application.UseCases.Expenses.GetAll;
public interface IGetAllExpensesUseCase
{
    Task<ResponseExpensesJson> Execute();
}
