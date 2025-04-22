using AutoMapper;
using Cashflow.Communication.Responses.Expenses;
using Cashflow.Domain.Repositories.Expenses;

namespace Cashflow.Application.UseCases.Expenses.GetAll;
public class GetAllExpensesUseCase(IExpensesReadOnlyRepository _expensesRepository, IMapper _mapper) : IGetAllExpensesUseCase
{
    public async Task<ResponseExpensesJson> Execute()
    {
       var entities = await _expensesRepository.GetAll();

       return new ResponseExpensesJson
       {
           Expenses = _mapper.Map<List<ResponseShortExpenseJson>>(entities)
       };
    }
}
