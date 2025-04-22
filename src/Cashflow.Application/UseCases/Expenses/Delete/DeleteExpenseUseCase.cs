
using Cashflow.Domain.Repositories;
using Cashflow.Domain.Repositories.Expenses;
using Cashflow.Exception;
using Cashflow.Exception.ExceptionsBase;

namespace Cashflow.Application.UseCases.Expenses.Delete;
public class DeleteExpenseUseCase(IExpensesWriteOnlyRepository _repository, IUnitOfWork _unitOfWork ) : IDeleteExpenseUseCase
{
    public async Task Execute(long id)
    {
        var result = await _repository.Delete(id);

        if (result is false)
        {
            throw new NotFoundException(ResourceErrorMessages.EXPENSE_NOT_FOUND);
        }

        await _unitOfWork.Commit();
    }
}
