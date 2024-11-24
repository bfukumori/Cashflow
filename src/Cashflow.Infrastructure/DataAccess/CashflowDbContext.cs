using Cashflow.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Cashflow.Infrastructure.DataAccess;
internal class CashflowDbContext(DbContextOptions options) : DbContext(options)
{
    public DbSet<Expense> Expenses { get; set; }
}