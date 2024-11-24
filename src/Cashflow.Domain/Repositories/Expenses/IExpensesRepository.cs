using Cashflow.Domain.Entities;

namespace Cashflow.Domain.Repositories.Expenses;
public interface IExpensesRepository
{
    Task Add(Expense expense);
    Task<List<Expense>> GetAll();
}
