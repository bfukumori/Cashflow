
using Cashflow.Domain.Reports;
using Cashflow.Domain.Repositories.Expenses;

namespace Cashflow.Application.UseCases.Expenses.Reports.Pdf;
public class GenerateExpensesReportPdfUseCase(IExpensesReadOnlyRepository _repository) : IGenerateExpensesReportPdfUseCase
{
    private readonly string CURRENCY_SYMBOL = ResourceReportGenerationMessages.CURRENCY_SYMBOL;
    public async Task<byte[]> Execute(DateOnly date)
    {
        var expenses = await _repository.FilterByMonth(date);

        if (expenses.Count == 0)
        {
            return [];
        }

        return [];
    }
}
