using AutoMapper;
using Cashflow.Communication.Responses.Expenses;
using Cashflow.Domain.Repositories.Expenses;
using Cashflow.Exception;
using Cashflow.Exception.ExceptionsBase;

namespace Cashflow.Application.UseCases.Expenses.GetById;
public class GetByIdUseCase(IExpensesReadOnlyRepository repository, IMapper _mapper) : IGetByIdUseCase
{
    public async Task<ResponseExpenseJson> Execute(long id)
    {
        var result = await repository.GetById(id);

        if (result is null)
        {
            throw new NotFoundException(ResourceErrorMessages.EXPENSE_NOT_FOUND);
        }

        return _mapper.Map<ResponseExpenseJson>(result);

    }
}
