namespace Cashflow.Exception.ExceptionsBase;
public abstract class CashflowException(string message) : SystemException(message)
{
    public abstract int StatusCode { get; }

    public abstract List<string> GetErrors();
}
