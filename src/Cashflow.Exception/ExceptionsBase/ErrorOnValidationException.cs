namespace Cashflow.Exception.ExceptionsBase;
public class ErrorOnValidationException(List<string> errorMessages) : CashflowException
{
    public List<string> Errors { get; set; } = errorMessages;
}
