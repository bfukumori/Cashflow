using Cashflow.Communication.Responses.Expenses;

namespace Cashflow.Application.UseCases.Expenses.GetById;
public interface IGetByIdUseCase
{
    Task<ResponseExpenseJson> Execute(long id);  
}
