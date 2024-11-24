using AutoMapper;
using Cashflow.Communication.Requests.Expenses;
using Cashflow.Communication.Responses.Expenses;
using Cashflow.Domain.Entities;
using Cashflow.Domain.Repositories;
using Cashflow.Domain.Repositories.Expenses;
using Cashflow.Exception.ExceptionsBase;

namespace Cashflow.Application.UseCases.Expenses.Register;
public class RegisterExpenseUseCase(IExpensesRepository _expensesRepository, IUnitOfWork _unitOfWork, IMapper _mapper) : IRegisterExpenseUseCase
{
    public async Task<ResponseRegisteredExpenseJson> Execute(RequestRegisterExpenseJson request)
    {
        Validate(request);

        var entity = _mapper.Map<Expense>(request);

        await _expensesRepository.Add(entity);
        await _unitOfWork.Commit();

        return _mapper.Map<ResponseRegisteredExpenseJson>(entity);
    }

    private static void Validate(RequestRegisterExpenseJson request)
    {
        var validator = new RegisterExpenseValidator();
        var result = validator.Validate(request);

        if (result.IsValid == false)
        {
            var errorMessages = result.Errors.Select(f => f.ErrorMessage).ToList();

            throw new ErrorOnValidationException(errorMessages);
        }
    }
}
