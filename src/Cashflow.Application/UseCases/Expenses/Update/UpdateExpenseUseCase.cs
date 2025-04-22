using AutoMapper;
using Cashflow.Communication.Requests.Expenses;
using Cashflow.Domain.Repositories;
using Cashflow.Domain.Repositories.Expenses;
using Cashflow.Exception;
using Cashflow.Exception.ExceptionsBase;

namespace Cashflow.Application.UseCases.Expenses.Update;
public class UpdateExpenseUseCase(IExpensesUpdateOnlyRepository _repository, IMapper _mapper, IUnitOfWork _unitOfWork) : IUpdateExpenseUseCase
{
    public async Task Execute(long id, RequestExpenseJson request)
    {
        Validate(request);

        var expense = await _repository.GetById(id) ?? throw new NotFoundException(ResourceErrorMessages.EXPENSE_NOT_FOUND);

        _mapper.Map(request, expense);

        _repository.Update(expense);

        await _unitOfWork.Commit();
    }

    private static void Validate(RequestExpenseJson request)
    {
        var validator = new ExpenseValidator();
        var result = validator.Validate(request);

        if (result.IsValid == false)
        {
            var errorMessages = result.Errors.Select(f => f.ErrorMessage).ToList();

            throw new ErrorOnValidationException(errorMessages);
        }
    }
}
