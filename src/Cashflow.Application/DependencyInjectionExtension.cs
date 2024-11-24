using Cashflow.Application.AutoMapper;
using Cashflow.Application.UseCases.Expenses.GetAll;
using Cashflow.Application.UseCases.Expenses.Register;
using Microsoft.Extensions.DependencyInjection;

namespace Cashflow.Application;

public static class DependencyInjectionExtension
{
    public static void AddApplication(this IServiceCollection services)
    {
        AddAutoMapper(services);
        AddUseCases(services);
    }

    private static void AddUseCases(IServiceCollection services)
    {
        services.AddScoped<IRegisterExpenseUseCase, RegisterExpenseUseCase>();
        services.AddScoped<IGetAllExpensesUseCase, GetAllExpensesUseCase>();
    }

    private static void AddAutoMapper(IServiceCollection services)
    {
        services.AddAutoMapper(typeof(AutoMapping));
    }
}
