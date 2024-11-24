using Cashflow.Domain.Repositories;

namespace Cashflow.Infrastructure.DataAccess.Repositories;
internal class UnitOfWork(CashflowDbContext _dbContext) : IUnitOfWork
{
    public async Task Commit() => await _dbContext.SaveChangesAsync();
}
