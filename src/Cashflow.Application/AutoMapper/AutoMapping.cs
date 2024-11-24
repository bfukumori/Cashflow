using AutoMapper;
using Cashflow.Communication.Requests.Expenses;
using Cashflow.Communication.Responses.Expenses;
using Cashflow.Domain.Entities;

namespace Cashflow.Application.AutoMapper;
public class AutoMapping : Profile
{
    public AutoMapping()
    {
        RequestToEntity();
        EntityToResponse();
    }

    private void RequestToEntity()
    {
        CreateMap<RequestRegisterExpenseJson, Expense>();
    }

    private void EntityToResponse()
    {
        CreateMap<Expense, ResponseRegisteredExpenseJson>();
        CreateMap<Expense, ResponseShortExpenseJson>();
    }
}
