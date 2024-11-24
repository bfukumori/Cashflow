using Cashflow.Domain.Entities;
using Cashflow.Domain.Repositories.Expenses;
using Microsoft.EntityFrameworkCore;

namespace Cashflow.Infrastructure.DataAccess.Repositories.Expenses;
internal class ExpensesRepository(CashflowDbContext _dbContext) : IExpensesRepository
{
    public async Task Add(Expense expense)
    {
        await _dbContext.Expenses.AddAsync(expense);
    }

    public async Task<List<Expense>> GetAll()
    {
        return await _dbContext.Expenses.AsNoTracking().ToListAsync();

    }
}
